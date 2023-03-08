using System.Threading.Tasks;

namespace LamyThematique.Infrastructure.Authentication.Interfaces
{
    public interface IUserAuthenticationMaboInfrastructure
    {

        Task<string> AuthenticationUserAsync(string remoteAddress, string xml);

    }
}
