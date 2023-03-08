using System.Xml.Serialization;

namespace LamyThematique.Infrastructure.Authentication.Models.Mabo.Dto
{
    public class UserRightsServicesModel
    {
        [XmlElement("product_service_code")]
        public string ProductServiceCode { get; set; }
        [XmlElement("service")]
        public string Service { get; set; }
        [XmlElement("acronym")]
        public string Acronym { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("expiration_date")]
        public string ExpirtationDate { get; set; }
    }
}
