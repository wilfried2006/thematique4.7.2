using System.Xml.Serialization;

namespace LamyThematique.Infrastructure.Authentication.Models.Mabo.Dto
{
    public partial class UserInfosModel
    {

        [XmlElement("user_type")]
        public string UserType { get; set; }

        [XmlElement("user_profil_id")]
        public string UserProfileId { get; set; }

        [XmlElement("expires_at")]
        public string ExpiresAt { get; set; }

        [XmlElement("user_max_access")]
        public string UserMaxAccess { get; set; }

        [XmlElement("customer_number")]
        public string CustomerNumber { get; set; }

        [XmlElement("contract_number")]
        public string ContractNumber { get; set; }

        [XmlElement("customer_segment")]
        public string CustomerSegment { get; set; }

        [XmlElement("customer_segment_id")]
        public string CustomerSegmentId { get; set; }

        [XmlElement("company_size")]
        public string CompanySize { get; set; }

        [XmlElement("demo_user")]
        public string DemoUser { get; set; }

        [XmlElement("contract_max_access")]
        public string ContractMaxAccess { get; set; }

        [XmlElement("contract_expiration_date")]
        public string ContractExpirationDate { get; set; }

        [XmlElement("access_code")]
        public string AccessCode { get; set; }

        [XmlElement("password")]
        public string Password { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("genre_id")]
        public string GenreId { get; set; }

        [XmlElement("lastname")]
        public string LastName { get; set; }

        [XmlElement("firstname")]
        public string FirstName { get; set; }

        [XmlElement("job_id")]
        public string JobId { get; set; }

        [XmlElement("address")]
        public string Address { get; set; }

        [XmlElement("additional_address")]
        public string AdditionalAddress { get; set; }

        [XmlElement("zipcode")]
        public string ZipCode { get; set; }

        [XmlElement("city")]
        public string City { get; set; }

        [XmlElement("country_id")]
        public string CountryId { get; set; }

        [XmlElement("phone_number")]
        public string PhoneNumber { get; set; }

        [XmlElement("fax_number")]
        public string FaxNumber { get; set; }

        [XmlElement("company")]
        public string Company { get; set; }

        [XmlElement("activity_domain_id")]
        public string ActivityDomainId { get; set; }

        [XmlElement("function")]
        public string Function { get; set; }

        [XmlElement("advertising")]
        public string Advertising { get; set; }


    }
}
