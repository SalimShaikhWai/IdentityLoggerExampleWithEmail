using IdentityLogger.Data.Models;
using IdentityLogger.Data.UtilityClass;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace IdentityLogger.Data.Service
{
    public class EmailService : IEmailService
    {
        private const string templatePath = @"./EmailTemplate/{0}.html";
       
        private readonly SMTPConfigModel _smptConfig;
        public async Task SendTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = "This is Test Email subject from Store";
            userEmailOptions.Body = GetEmailBody("TestEmail");
            await SendEmail(userEmailOptions);

        }
        public EmailService(IOptions<SMTPConfigModel> smptConfig)
        {
            _smptConfig = smptConfig.Value;
        }

        private async Task SendEmail(UserEmailOptions userMailOptions)
        {
            MailMessage mail = new MailMessage
            {
                Subject = userMailOptions.Subject,
                Body = userMailOptions.Body,
                From = new MailAddress(_smptConfig.SenderAddress, _smptConfig.SendDisplayName),
                IsBodyHtml = _smptConfig.IsBodyHTML

            };

            foreach (var toEmail in userMailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }

            NetworkCredential networkCrediantial = new(_smptConfig.UserName, _smptConfig.Password);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = _smptConfig.Host,
                Port = _smptConfig.Port,
                EnableSsl = _smptConfig.EnableSSL,
                UseDefaultCredentials = _smptConfig.UseDefaultCredentials,
                Credentials = networkCrediantial,
              
        };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);

        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
    }
}
