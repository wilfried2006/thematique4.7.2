using System.Threading.Tasks;
using LamyThematique.Domain.User.ValueObjects;
using LamyThematique.ViewModels.Web.Models.Authentication;

namespace LamyThematique.Domain.User.Interfaces.Services
{
    public interface IUserAuthenticationService
    {
        Task<UserAuthAppResultVo> AuthenticateUserAsync(AuthenticationFormViewModel authenticationFormViewModel);
    }
}
