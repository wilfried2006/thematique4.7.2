using System.Xml.Serialization;

namespace LamyThematique.Infrastructure.Authentication.Models.Mabo.Dto
{
    [XmlRoot("result_auth_user")]
    public class UserAuthenticationResultModel
    {
        [XmlElement("auth")]
        public string ResultCode { get; set; }

        [XmlElement("error_number")]
        public string ErrorNumber { get; set; }

        [XmlElement("session_number")]
        public string SessionNumber { get; set; }

        [XmlElement("session_status")]
        public string SessionStatus { get; set; }

        [XmlElement("user_token")]
        public string UserToken { get; set; }

        [XmlElement("user_parent_infos")]
        public ParentUserInfosModel ParentUserInfos { get; set; }

        [XmlElement("user_infos")]
        public UserInfosModel UserInfos { get; set; }

        [XmlElement("user_settings")]
        public UserInfosModel UserSettings { get; set; }

        [XmlElement("user_rights")]
        public UserRightsModel UserRights { get; set; }
    }
}
