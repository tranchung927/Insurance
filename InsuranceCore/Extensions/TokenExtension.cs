using InsuranceCore.Models.Settings;
using InsuranceCore.Services.Interface;
using InsuranceCore.Services.TokenService;

namespace InsuranceCore.Extensions
{
    public static class TokenExtension
    {
        public static IServiceCollection RegisterTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenSettings>(configuration.GetSection("TokenConfiguration"));
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
