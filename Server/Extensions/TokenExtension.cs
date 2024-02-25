using Server.Models.Settings;
using Server.Services.Interface;
using Server.Services.TokenService;

namespace Server.Extensions
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
