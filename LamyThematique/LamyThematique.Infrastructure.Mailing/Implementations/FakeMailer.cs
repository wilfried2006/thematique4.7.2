using System.Threading.Tasks;
using LamyThematique.Domain;

namespace LamyThematique.Infrastructure.Mailing.Implementations
{
    internal class FakeMailer : IMailer
    {
        public Task SendEmailAsync(string toEmail, string fromEmail, string subject, string htmlBody, string name)
        {
            return Task.CompletedTask;
        }
    }
}
