using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FoodHeaven.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var smtpServer = _configuration["EmailSettings:SmtpServer"];
            var portString = _configuration["EmailSettings:Port"];
            var senderEmail = _configuration["EmailSettings:SenderEmail"];
            var senderName = _configuration["EmailSettings:SenderName"];
            var username = _configuration["EmailSettings:Username"];
            var password = _configuration["EmailSettings:Password"];

            // Basic validation to ensure configuration is present
            if (string.IsNullOrEmpty(smtpServer) || string.IsNullOrEmpty(senderEmail) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                 System.Console.WriteLine("Email settings are missing in appsettings.json. Email not sent.");
                 return;
            }

            int port = 587; // default
            if (!string.IsNullOrEmpty(portString))
            {
                int.TryParse(portString, out port);
            }

            try 
            {
                var email = new MimeMessage();
                email.From.Add(new MailboxAddress(senderName ?? senderEmail, senderEmail));
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = subject;

                var builder = new BodyBuilder { HtmlBody = message };
                email.Body = builder.ToMessageBody();

                using var smtp = new SmtpClient();
                
                // For Gmail port 587, use StartTls
                // For port 465, use SslOnConnect
                await smtp.ConnectAsync(smtpServer, port, SecureSocketOptions.StartTls);
                
                await smtp.AuthenticateAsync(username, password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
                
                System.Console.WriteLine($"[EMAIL SUCCESS] Sent to: {toEmail}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"[EMAIL FAILURE] Error sending to {toEmail}: {ex.Message}");
                // We re-throw to allow the calling controller's try-catch to handle it or log it
                throw;
            }
        }
    }
}
