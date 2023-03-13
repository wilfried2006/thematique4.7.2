using LamyThematique.ViewModels.Web.Pages.Test;
using System.Threading.Tasks;

namespace LamyThematique.Domain.Document.Interfaces.Services
{
    public interface IGetFiltersDataService
    {
        Task<SearchResultPageViewModel> GetSearchResultPageAsync();
    }
}
