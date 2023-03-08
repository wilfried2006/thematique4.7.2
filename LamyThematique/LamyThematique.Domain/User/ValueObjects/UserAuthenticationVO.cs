namespace LamyThematique.Domain.User.ValueObjects
{
    public class UserAuthenticationVO
    {
        public string AccessCode { get; set; }

        public string Password { get; set; }

        public string IpAddress { get; set; }
    }
}
