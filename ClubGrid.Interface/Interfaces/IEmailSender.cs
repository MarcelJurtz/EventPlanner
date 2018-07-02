using System.Threading.Tasks;

namespace ClubGrid.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmail(string recipient, string subject, string content);
    }
}
