using AutoMapper.Internal;
using LMS.Domain.Model.Mail;
using Microsoft.Extensions.Options;
using MimeKit;

using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using System.Security.Cryptography.X509Certificates;




namespace LMS.Application.Service;

public class EmailService(IOptions<EmailSetting> options) : IEmailService
{
    
    private readonly EmailSetting emailSettings = options.Value;

    public async Task SendEamilAsync(MailRequest mailrequest)
    {
        var email = new MimeMessage();
        email.Sender = MailboxAddress.Parse(emailSettings.Email);
        email.To.Add(MailboxAddress.Parse(mailrequest.ToEmail));
        email.Subject = mailrequest.Subject;
        var builder = new BodyBuilder();


        //byte[] fileBytes;
        //if (System.IO.File.Exists("Attachment/dummy.pdf"))
        //{
        //    FileStream file = new FileStream("Attachment/dummy.pdf", FileMode.Open, FileAccess.Read);
        //    using (var ms = new MemoryStream())
        //    {
        //        file.CopyTo(ms);
        //        fileBytes = ms.ToArray();
        //    }
        //    builder.Attachments.Add("attachment.pdf", fileBytes, ContentType.Parse("application/octet-stream"));
        //    builder.Attachments.Add("attachment2.pdf", fileBytes, ContentType.Parse("application/octet-stream"));
        //}

        builder.HtmlBody = mailrequest.Body;
        email.Body = builder.ToMessageBody();
      

        using var smtp = new SmtpClient();
        smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(emailSettings.Email, emailSettings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);


        
    }
}