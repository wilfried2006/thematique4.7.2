using System.Collections.Generic;
using System.Text.Json.Serialization;
using LamyThematique.ViewModels.Web.Enums;

namespace LamyThematique.ViewModels.Web.Pages.Shared.Search
{
    public class SearchFilterViewModel
    {
        [JsonPropertyName("filtreThemes")]
        public List<int> FiltresTheme { get; set; }

        [JsonPropertyName("filtreTypes")]
        public List<ContentType> ContentTypes { get; set; }
    }
}