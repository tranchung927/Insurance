using Server.Models.Mail;

namespace Server.Services.MailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(Message message, CancellationToken token);
    }
}
