using MimeKit;
using SendEmail.Model;
using MailKit.Net.Smtp;

namespace SendEmail.Services
{
  public class EmailService
    {
        public async Task SendEmailAsync(EmailModel email)
        {
            // ساخت ایمیل
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Omid Sargazi", "osargazi87@gmail.com"));
            message.To.Add(new MailboxAddress("", email.To));
            message.Subject = email.Subject;

            message.Body = new TextPart("plain")
            {
                Text = email.Body
            };

            // اتصال به سرور Gmail
            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);

            // استفاده از App Password
            await client.AuthenticateAsync("osargazi87@gmail.com", "rqcp xzif ekcv xlld");

            // ارسال ایمیل
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}