using InsuranceCore.Models.Settings;
using InsuranceCore.Services.MailService;

namespace InsuranceCore.Extensions
{
    public static class MailExtensions
    {
        public static IServiceCollection RegisterMailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailConfigurationSettings>(configuration.GetSection(EmailConfigurationSettings.Position));
            services.AddScoped<IEmailService, EmailService>();
            return services;
        }

    }
}
