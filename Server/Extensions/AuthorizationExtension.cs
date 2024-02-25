using Microsoft.AspNetCore.Authorization;
using Server.Authorization;

namespace Server.Extensions
{
    public static class AuthorizationExtension
    {
        public static IServiceCollection RegisterAuthorization(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.RegisterAuthorizationHandlers();
            return services;
        }
    }
}
