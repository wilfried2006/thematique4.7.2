namespace LamyThematique.ViewModels.Web.Pages.UserProfile
{
    public  class UserProfileViewModel
    {
        public string FirstName { get; set; } = "Sandrine";
        public string LastName { get; set; } = "Sandrine";
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        public string Email { get; set; }

        public string Identity { get; set; }
    }
}
