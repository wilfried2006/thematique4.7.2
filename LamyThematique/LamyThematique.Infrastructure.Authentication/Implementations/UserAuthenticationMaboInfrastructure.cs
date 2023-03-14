using System.Threading.Tasks;
using LamyThematique.Infrastructure.Authentication.Interfaces;
using LamyThematique.Infrastructure.Authentication.MaboReferenceClient;

namespace LamyThematique.Infrastructure.Authentication.Implementations
{
    internal class UserAuthenticationMaboInfrastructure : IUserAuthenticationMaboInfrastructure
    {
        public IdentificationPortTypeClient MaboClient { get; set; }

        public async Task<string> AuthenticationUserAsync(string remoteAddress, string xml)
        {
            //maboClient = new IdentificationPortTypeClient(IdentificationPortTypeClient. EndpointConfiguration.IdentificationPort, remoteAddress);

            MaboClient = new IdentificationPortTypeClient();

            return await MaboClient.AuthentificationUserAsync(xml);
        }
    }
}
