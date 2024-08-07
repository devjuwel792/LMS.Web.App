using LMS.Domain.Model.Mail;

namespace LMS.Application.Service
{
    public interface IEmailService
    {
        Task SendEamilAsync(MailRequest mailRequest);
    }
}