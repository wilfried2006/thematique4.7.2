using LamyThematique.ViewModels.Web.Pages.Shared;
using Schema.NET;

namespace LamyThematique.ViewModels.Web.Pages.Home
{
    public class IndexPageViewModel
    {
        public HeaderViewModel Header { get; set; }

        #region JSON LD Classes
        public Person Author { get; set; }
        public Organization Organization { get; set; }
        #endregion
    }
}