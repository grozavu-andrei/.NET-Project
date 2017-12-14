using System.Threading.Tasks;

namespace VirtualSecretary.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
