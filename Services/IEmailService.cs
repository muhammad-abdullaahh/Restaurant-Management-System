using System.Threading.Tasks;

namespace FoodHeaven.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
