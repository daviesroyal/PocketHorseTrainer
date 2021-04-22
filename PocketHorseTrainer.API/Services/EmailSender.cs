using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PocketHorseTrainer.API.Services
{
    public class EmailSender : IEmailSender
    {
        public SendGridEmailSenderOptions Options { get; set; }

        public EmailSender(IOptions<SendGridEmailSenderOptions> options) => Options = options.Value;

        public Task SendEmailAsync(
            string email,
            string subject,
            string message) => Execute(Options.ApiKey, subject, message, email);

        private Task<Response> Execute(
            string apiKey,
            string subject,
            string message,
            string email)
        {
            SendGridMessage msg = new()
            {
                From = new EmailAddress(Options.SenderEmail, Options.SenderName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // disable tracking settings
            // ref.: https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);
            msg.SetOpenTracking(false);
            msg.SetGoogleAnalytics(false);
            msg.SetSubscriptionTracking(false);

            return new SendGridClient(apiKey).SendEmailAsync(msg);
        }
    }
}
