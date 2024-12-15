using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace EcommerceProject.Utils
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration config,ILogger<EmailSender>logger)
        {
            _config = config;
            _logger = logger;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Fetch SMTP settings from configuration
            var smtpHost = Environment.GetEnvironmentVariable("SMTP_HOST");
            var smtpPort = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT")); // Use SMTP_PORT here
            var enableSsl = bool.Parse(Environment.GetEnvironmentVariable("SMTP_ENABLESSL"));
            var emailFrom = Environment.GetEnvironmentVariable("SMTP_EMAILFROM");
            var username = Environment.GetEnvironmentVariable("SMTP_USERNAME");
            var password = Environment.GetEnvironmentVariable("SMTP_PASSWORD");


            // Create a new SmtpClient instance
            using (var client = new SmtpClient(smtpHost, smtpPort))
            {
                client.Credentials = new NetworkCredential(username, password);
                client.EnableSsl = enableSsl;

                // Create the email message
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailFrom, "Ecommerce Project"),
                    Subject = subject,
                    Body = htmlMessage,
                    IsBodyHtml = true // Set the body as HTML
                };

                mailMessage.To.Add(new MailAddress(email));
                _logger.LogInformation("Send Email: {Email}", mailMessage);
                // Send email asynchronously
                await client.SendMailAsync(mailMessage);
            }
        }
    }
}
