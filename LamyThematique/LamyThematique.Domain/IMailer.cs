using System.Threading.Tasks;

namespace LamyThematique.Domain
{
    public interface IMailer
    {
        Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlBody, string name);
    }
}