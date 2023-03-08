using LamyThematique.Domain.User.Interfaces.Services;
using LamyThematique.ViewModels.Web.Pages.Home;
using LamyThematique.ViewModels.Web.Pages.Shared;

namespace LamyThematique.Application.Web.Implementations
{
    internal class GetUserPageService : IGetUserPageService
    {
        public IndexPageViewModel GetIndex(int? userId)
        {
            return new IndexPageViewModel()
            {
                Header = new HeaderViewModel()
                {
                    UserFirstname = "UserFirstname",
                    UserLastname = "UserLastname"
                }
            };
        }
    }
}
