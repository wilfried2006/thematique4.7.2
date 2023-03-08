using System.Xml.Serialization;

namespace LamyThematique.Infrastructure.Authentication.Models.Mabo.Dto
{
    public class ParentUserInfosModel
    {
        [XmlElement("access_code")]
        public string AccessCode { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }
    }
}
