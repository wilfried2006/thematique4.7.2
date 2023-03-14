using LamyThematique.ViewModels.Web.Models.Search;
using LamyThematique.ViewModels.Web.Pages.Test;
using System.Collections.Generic;
using System.Threading.Tasks;
using LamyThematique.Domain.Document;

namespace LamyThematique.Domain.User.Interfaces
{
    public interface IDocumentRepository
    {
        Task<List<Sujet>> GetSujetsItemsAsync(int? sousThemeId = null);

        Task<List<SousTheme>> GetSousThemesItemsAsync(int? themeId = null);

        Task<List<Theme>> GetThemesItemsAsync();
    }
}
