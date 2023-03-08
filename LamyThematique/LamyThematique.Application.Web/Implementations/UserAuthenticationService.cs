using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using LamyThematique.Domain.Helpers;
using LamyThematique.Domain.User.Interfaces;
using LamyThematique.Domain.User.ValueObjects;
using LamyThematique.Infrastructure.Authentication.Interfaces;
using LamyThematique.Infrastructure.Authentication.Models.Mabo;
using LamyThematique.ViewModels.Web.Models.Authentication;

namespace LamyThematique.Application.Web.Implementations
{
    internal class UserAuthenticationService : Domain.User.Interfaces.Services.IUserAuthenticationService
    {
        public IUserAuthenticationInfrastructure userAuthenticationInfrastructure { get; set; }

        public IUserRepository _userRepository { get; set; }

        public UserAuthenticationService(IUserAuthenticationInfrastructure userAuthenticationInfrastructure, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            this.userAuthenticationInfrastructure = userAuthenticationInfrastructure;
        }

        public UserAuthenticationService()
        {
        }

        public async Task<UserAuthenticationResponse> GEtresponse(UserAuthenticationVO userAuthRequest) => 
            await userAuthenticationInfrastructure.AuthentificateUserAsync(userAuthRequest);

        public async Task<UserAuthAppResultVO> AuthenticateUserAsync(AuthenticationFormViewModel authenticationFormViewModel)
        {
            var userClaims = new List<Claim>();

            var user = await _userRepository.GetUserAccessCodeAsync(authenticationFormViewModel.Email);

            var userAuthRequest = new UserAuthenticationVO
            {
                Password = authenticationFormViewModel.Password,
                AccessCode = user.AccessCode,
                IpAddress = NetworkHelper.GetLocalIPAddress()
            };

            var maboAuthenticationResult = await userAuthenticationInfrastructure.AuthentificateUserAsync(userAuthRequest);

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

            return new UserAuthAppResultVO()
            {
                ResultCode = maboAuthenticationResult.ResultCode,
                ClaimsIdentity = claimsIdentity
            };
        }
    }
}
