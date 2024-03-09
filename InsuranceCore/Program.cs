using InsuranceCore.Extensions.FluentValidation;
using InsuranceCore.Extensions;
using System.Text.Json.Serialization;
using InsuranceCore.DataContext;
using Microsoft.AspNetCore.Identity;
using InsuranceCore.Data;
using Serilog;
using InsuranceCore.Models.Settings;
using InsuranceCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Host.RegisterLoggerConfiguration();
builder.Services.AddHttpContextAccessor();
builder.Services.RegisterFluentValidation();
builder.Services.RegisterDatabaseProvider(configuration);

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.RegisterIdentity();

builder.Services.RegisterRepositoryServices();
builder.Services.RegisterResourceServices();
builder.Services.RegisterDtoResourceValidators();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.RegisterMailService(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterSwagger();

builder.Services.RegisterAuthorization();

builder.Services.RegisterTokenConfiguration(configuration);
var jwtSettings = configuration.GetSection("TokenConfiguration").Get<TokenSettings>();
builder.Services.RegisterAuthentication(jwtSettings);

var logSettings = configuration.GetSection(SerilogSettings.Position).Get<SerilogSettings>();
if (!string.IsNullOrEmpty(logSettings?.MinimumLevel?.Default) &&
    (string.Equals(logSettings.MinimumLevel.Default, "debug", StringComparison.OrdinalIgnoreCase) ||
    string.Equals(logSettings.MinimumLevel.Default, "verbose", StringComparison.OrdinalIgnoreCase)))
{
    builder.Services.AddAllHttpLoggingInformationAvailable();
}

var app = builder.Build();

app.UseExceptionHandler("/error");
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "InsuranceServer V1");
});
app.UseCors(options =>
{
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseHttpLogging()
    .UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await FillInDatabase();

app.Run();

async Task FillInDatabase()
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<InsuranceDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
    await DbInitializer.SeedWithDefaultValues(context, roleManager, userManager);
}

namespace InsuranceCore
{
    public partial class Program { }
}

