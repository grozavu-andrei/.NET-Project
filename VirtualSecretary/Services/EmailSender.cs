using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace VirtualSecretary.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var fromAddress = new MailAddress(Options.AppEmail, "VirtualSecretary");
            var toAddress = new MailAddress(email, "Subscriber");
            string fromPassword = Options.AppPass;
            const string subj = "Subject";
            string body = message;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var mesg = new MailMessage(fromAddress, toAddress)
            {
                Subject = subj,
                Body = body
            })
            {
                smtp.Send(mesg);
            }
            return Task.CompletedTask;
        }

    }
}
