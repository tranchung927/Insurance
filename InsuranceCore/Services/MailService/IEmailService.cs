using InsuranceCore.Models.Mail;

namespace InsuranceCore.Services.MailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(Message message, CancellationToken token);
    }
}
