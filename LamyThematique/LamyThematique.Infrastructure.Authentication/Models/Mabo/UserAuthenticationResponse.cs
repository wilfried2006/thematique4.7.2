namespace LamyThematique.Infrastructure.Authentication.Models.Mabo
{
    public class UserAuthenticationResponse
    {
        public string SessionNumber { get; set; }
        public string AccessCode { get; set; }
        public string Email { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string ResultCode { get; set; }
    }
}
