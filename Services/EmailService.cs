using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
namespace MyProject.Services
{
    public static class EmailService
    {
        public static async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient("YOUR_SENDGRID_API_KEY");// لسه ناقص
            var from = new EmailAddress("no-reply@yourapp.com", "Your App Name");// لسه ناقص
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);
            await client.SendEmailAsync(msg);
        }
    }
}
