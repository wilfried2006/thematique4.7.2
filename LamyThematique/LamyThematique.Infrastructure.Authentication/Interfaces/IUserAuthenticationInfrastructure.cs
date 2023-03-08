using System.Threading.Tasks;
using LamyThematique.Domain.User.ValueObjects;
using LamyThematique.Infrastructure.Authentication.Models.Mabo;

namespace LamyThematique.Infrastructure.Authentication.Interfaces
{
    public interface IUserAuthenticationInfrastructure
    {
        Task<UserAuthenticationResponse> AuthentificateUserAsync(UserAuthenticationVO authModel);
    }
}