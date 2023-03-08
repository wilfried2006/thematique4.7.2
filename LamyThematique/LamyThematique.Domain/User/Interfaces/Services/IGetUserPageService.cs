using LamyThematique.ViewModels.Web.Pages.Home;

namespace LamyThematique.Domain.User.Interfaces.Services
{
    public interface IGetUserPageService
    {
        IndexPageViewModel GetIndex(int? userId);
    }
}
