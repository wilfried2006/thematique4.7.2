using System.IO;
using System.Xml.Serialization;

namespace LamyThematique.Infrastructure.Authentication
{
    [XmlRoot("auth_user")]
    public class UserAuthenticationModel
    {
        [XmlElement("access_code")]
        public string AccessCode { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("portal_id")]
        public string PortalId { get; set; }

        [XmlElement("auth_method")]
        public string AuthMethod { get; set; }

        [XmlElement("ip_address")]
        public string IpAddress { get; set; }

        public string Serialize()
        {
            var sw = new StringWriter();
            var serializer = new XmlSerializer(typeof(UserAuthenticationModel));
            serializer.Serialize(sw, this);
            return sw.ToString();
        }
    }
}
