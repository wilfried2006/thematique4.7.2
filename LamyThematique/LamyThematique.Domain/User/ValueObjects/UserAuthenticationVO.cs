namespace LamyThematique.Domain.User.ValueObjects
{
    public class UserAuthenticationVo
    {
        public string AccessCode { get; set; }

        public string Password { get; set; }

        public string IpAddress { get; set; }
    }
}
