using System.Xml.Serialization;

namespace LamyThematique.Infrastructure.Authentication.Models.Mabo.Dto
{
    public class UserRightsModel
    {
        [XmlElement("services")]
        public UserRightsServicesModel[] UserRightsServices { get; set; }
    }

}
