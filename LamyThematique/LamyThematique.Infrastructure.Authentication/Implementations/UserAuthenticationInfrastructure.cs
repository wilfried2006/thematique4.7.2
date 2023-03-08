using System;
using System.Threading.Tasks;
using LamyThematique.Domain.Common;
using LamyThematique.Domain.Helpers;
using LamyThematique.Domain.User.ValueObjects;
using LamyThematique.Infrastructure.Authentication.Interfaces;
using LamyThematique.Infrastructure.Authentication.Models.Mabo;
using LamyThematique.Infrastructure.Authentication.Models.Mabo.Dto;
using Microsoft.Extensions.Options;

namespace LamyThematique.Infrastructure.Authentication.Implementations
{
    internal class UserAuthenticationInfrastructure : IUserAuthenticationInfrastructure
    {
        public AppSettings _appSettings { get; set; }

        public IUserAuthenticationMaboInfrastructure UserAuthenticationMaboInfrastructure { get; set; }

        public UserAuthenticationInfrastructure() { }

        public UserAuthenticationInfrastructure(IOptions<AppSettings> appSettings, IUserAuthenticationMaboInfrastructure userAuthenticationMaboInfrastructure)
        {
            UserAuthenticationMaboInfrastructure = userAuthenticationMaboInfrastructure;
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));

            //UserAuthenticationMaboInfrastructure.
            //maboClient = new IdentificationPortTypeClient(IdentificationPortTypeClient.EndpointConfiguration.IdentificationPort, _appSettings.MaboWSUri);
        }

        public async Task<UserAuthenticationResponse> AuthentificateUserAsync(UserAuthenticationVO authModel)
        {
            var request = new UserAuthenticationModel()
            {
                AccessCode = authModel.AccessCode,
                IpAddress = authModel.IpAddress,
                Password = authModel.Password,
                AuthMethod = "access_code",
                PortalId = "SOLVEORH"
            };

            var xmlRequest = XmlHelper.SerializeToXmlString(request);

            var strResponse = await UserAuthenticationMaboInfrastructure.AuthenticationUserAsync(_appSettings?.MaboWSUri, xmlRequest);

            //maboClient.AuthentificationUserAsync(xmlRequest);

            //_logger.LogInformation($"MaboUserService - AuthentificationUserAsync raw response : {strResponse}");

            var response = XmlHelper.DeserializeFromXmlString<UserAuthenticationResultModel>(strResponse);

            if (response == null)
            {
                //_logger.LogInformation($"MaboUserService - AuthentificationUserAsync returned null");
            }


            return new UserAuthenticationResponse()
            {
                AccessCode = response?.UserInfos?.AccessCode,
                Email = response?.UserInfos?.Email,
                Firstname = response?.UserInfos?.FirstName,
                Lastname = response?.UserInfos?.LastName,
                SessionNumber = response?.SessionNumber,
                ResultCode = response?.ResultCode
            };
        }
    }
}
