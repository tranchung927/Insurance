
// Tạo một đối tượng WebApplicationBuilder mới gọi là builder nhằm khởi tạo và cấu hình ứng dụng web.
// Đối tượng builder đóng vai trò là nền tảng để thêm các dịch vụ và cấu hình cho ứng dụng trước khi khởi chạy.

using Server.Data.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Server.Repositories.Users.Interface;
using Server.Repositories.Users;
using Server.Repositories;
using Server.Models.ClientSupport;
using Server.Repositories.ClientSupport;
using Server.Models.LifeInsurance;
using Server.Repositories.LifeInsurance;
using Server.Models.VehicleInsurance;
using Server.Repositories.VehicleInsurance;

var builder = WebApplication.CreateBuilder(args);

// Thêm hỗ trợ MVC vào ứng dụng, cho phép tạo và sử dụng các controller để xử lý các yêu cầu web.
builder.Services.AddControllers();

// Thêm hỗ trợ để khám phá các API endpoint trong ứng dụng, giúp hiển thị thông tin về các API có sẵn.
builder.Services.AddEndpointsApiExplorer();

// Thêm hỗ trợ Swagger, một công cụ giúp tạo tài liệu và thử nghiệm các API theo cách trực quan và dễ dàng.
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

// Bật tính năng CORS (Cross-Origin Resource Sharing),
// Dưới đây là một số ví dụ về cách sử dụng chức năng này:
// Bạn có thể cho phép các ứng dụng web từ miền của mình lấy tất cả các API trong ứng dụng.
// Bạn có thể cho phép các ứng dụng web từ một miền có thể lấy một API cụ thể.
// Bạn có thể cho phép các ứng dụng web từ một miền có thể lấy một số API cụ thể.
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));  // (hiện tại đang cho phép tất cả các nguồn)

// Đây là phương thức để đăng ký dịch vụ Identity trong ứng dụng của bạn
builder.Services.AddIdentity<UserEntity, IdentityRole>()
    .AddEntityFrameworkStores<Web_Context>()
    .AddDefaultTokenProviders();

//  đăng ký một lớp dịch vụ DbContext có tên là Web_Context.
// sử dụng GetConnectionString để lấy chuỗi kết nối từ cấu hình ứng dụng theo tên "aptechProject"
builder.Services.AddDbContext<Web_Context>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("aptechProject"));
});


// Dòng này sẽ đăng ký AutoMapper với thùng chứa DI. AutoMapper sẽ được sử dụng để ánh xạ giữa các lớp trong ứng dụng.
// không cần khai báo đường dẫn file cấu hình mapper với Program.
// AutoMapper sẽ tự động quét lớp Program và các lớp kế thừa từ Program
// để tìm kiếm các lớp cấu hình mapper. Các ánh xạ được xác định trong các
// lớp cấu hình mapper này sẽ được tự động phát hiện và đăng ký.
builder.Services.AddAutoMapper(typeof(Program));

// đăng ký các dịch vụ (services) vào container DI (Dependency Injection) của ứng dụng.
// đăng ký các lớp repository với phạm vi "Scoped". Điều này sẽ đảm bảo rằng mỗi yêu cầu web
// sẽ có một thể hiện riêng của các lớp repository, và dữ liệu sẽ không bị lẫn lộn giữa các yêu cầu khác nhau.

builder.Services.AddScoped<IRepository<JobsRiskModel>, JobsRisk_Repo>();
builder.Services.AddScoped<IUsers_Repo,Users_Repo>();
builder.Services.AddScoped<IRepository<InformationModel>, ClientSupport_Repo>();
builder.Services.AddScoped<IRepository<DeathRateModel>, DeathRate_Repo>();
builder.Services.AddScoped<IRepository<VehicleTypeModel>, VehicleType_Repo>();
builder.Services.AddScoped<IRepository<VehiclePropertyModel>, VehicleProperty_Repo>();
builder.Services.AddScoped<IRepository<WorkplaceModel>, Workplace_Repo>();


// Thêm dịch vụ xác thực vào DI container của ứng dụng.
builder.Services.AddAuthentication(options =>
{
    // Thiết lập để sử dụng JWT làm giải pháp mặc định cho cơ chế xác thực và thách thức.
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    // Lưu trữ token được gửi trong yêu cầu để sử dụng trong việc xác minh.
    options.SaveToken = true;
    // Yêu cầu sử dụng HTTPS để gửi token.
    options.RequireHttpsMetadata = true;
    // Cung cấp các tham số cần thiết cho quá trình xác thực token.
    options.TokenValidationParameters = new
    Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        // Các tham số của token

        // Xác nhận tính hợp lệ của Issuer (đơn vị phát hành token)
        ValidateIssuer = true,
        // Xác nhận tính hợp lệ của Audience (đối tượng mà token được phát cho)
        ValidateAudience = true,
        // Thiết lập giá trị Audience được chấp nhận từ cấu hình ứng dụng.
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        // Thiết lập giá trị Issuer được chấp nhận từ cấu hình ứng dụng.
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        // Sử dụng khóa đối xứng để xác thực chữ ký của token.
        // Khóa này được lấy từ cấu hình ứng dụng và dùng để ký và xác nhận tính hợp lệ của token.
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                builder.Configuration["JWT:Secret"]
                )
            )
    };
});


// Xây dựng ứng dụng web dựa trên các cấu hình để thiết lập và lưu vào đối tượng app.
var app = builder.Build();

// Cấu hình ứng dụng để sử dụng các tập mặc định (như index.html) nếu đường dẫn URL không chỉ định có thể mất tập nào.
app.UseDefaultFiles();

// Bật tính năng phục vụ các tập tin tĩnh (như CSS, JavaScript, hình ảnh) từ thư mục wwwroot của ứng dụng.
app.UseStaticFiles();

// Kiểm tra xem ứng dụng có đang chạy ở môi trường phát triển hay không.
// Nếu có, thực hiện các cấu hình bổ sung dành riêng cho môi trường phát triển.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Chuyển hướng các yêu cầu HTTP sang HTTPS để đảm bảo giao tiếp an toàn.
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();


// Bật tính năng phân quyền, cho phép kiểm soát quyền truy cập vào các API và tài nguyên của ứng dụng.
app.UseAuthorization();


// Đăng ký các controller MVC trong ứng dụng, cho phép chúng xử lý các yêu cầu web.
app.MapControllers();

// Cấu hình ứng dụng để hiển thị tập tin index.html nếu không tìm thấy đường dẫn URL phù hợp với bất kỳ controller nào.
app.MapFallbackToFile("/index.html");

// Khởi chạy ứng dụng web và bắt đầu lắng nghe các yêu cầu từ người dùng.
app.Run();
