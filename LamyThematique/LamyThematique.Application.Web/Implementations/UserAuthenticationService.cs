using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LamyThematique.Domain.Helpers;
using LamyThematique.Domain.User.Interfaces;
using LamyThematique.Domain.User.Interfaces.Services;
using LamyThematique.Domain.User.ValueObjects;
using LamyThematique.Infrastructure.Authentication.Interfaces;
using LamyThematique.Infrastructure.Authentication.Models.Mabo;
using LamyThematique.ViewModels.Web.Models.Authentication;

namespace LamyThematique.Application.Web.Implementations
{
    internal class UserAuthenticationService : IUserAuthenticationService
    {
        public IUserAuthenticationInfrastructure UserAuthenticationInfrastructure { get; set; }

        public IUserRepository UserRepository { get; set; }

        public UserAuthenticationService()
        {
        }

        public UserAuthenticationService(IUserAuthenticationInfrastructure userAuthenticationInfrastructure, IUserRepository userRepository)
        {
            UserRepository = userRepository;
            UserAuthenticationInfrastructure = userAuthenticationInfrastructure;
        }

        public async Task<UserAuthenticationResponse> GEtresponse(UserAuthenticationVo userAuthRequest) =>
            await UserAuthenticationInfrastructure.AuthentificateUserAsync(userAuthRequest);

        public async Task<UserAuthAppResultVo> AuthenticateUserAsync(AuthenticationFormViewModel authenticationFormViewModel)
        {
            var userClaims = new List<Claim>();

            var user = await UserRepository.GetUserAccessCodeAsync(authenticationFormViewModel.Email);

            var userAuthRequest = new UserAuthenticationVo
            {
                Password = authenticationFormViewModel.Password,
                AccessCode = user.AccessCode,
                IpAddress = NetworkHelper.GetLocalIpAddress()
            };

            var maboAuthenticationResult = await UserAuthenticationInfrastructure.AuthentificateUserAsync(userAuthRequest);

            if (maboAuthenticationResult.ResultCode == "ok")
            {
                userClaims.Add(new Claim("access_code", maboAuthenticationResult.AccessCode));
                userClaims.Add(new Claim("session_number", maboAuthenticationResult.SessionNumber));
                userClaims.Add(new Claim("firstname", maboAuthenticationResult.Firstname));
                userClaims.Add(new Claim("lastname", maboAuthenticationResult.Lastname));

                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            }
            else
            {
                //pas de connection pour xxx raisons
            }

            var claimsIdentity = new ClaimsIdentity(userClaims, "authentication");

            return new UserAuthAppResultVo()
            {
                ResultCode = maboAuthenticationResult.ResultCode,
                ClaimsIdentity = claimsIdentity
            };
        }
    }
}
