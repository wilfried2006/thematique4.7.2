using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using LamyThematique.ViewModels.Web.Models.Search;

namespace LamyThematique.ViewModels.Web.Pages.Test
{
    public class SearchResultPageViewModel
    {
        [JsonPropertyName("SelectedItems")]
        public List<int> SelectedItems => SelectFilters.SelectMany(x => x.Items).Where(x=>x.Selected).Select(x=>x.Id).ToList();

        [JsonPropertyName("selectFilters")]
        public List<SearchSelectsViewModel> SelectFilters { get; set; }

        [JsonPropertyName("items")]
        public List<SearchContentResultItem> Resultat { get; set; }

        [JsonPropertyName("types")]
        public List<SearchCheckboxViewModel> Types { get; set; }

        [JsonPropertyName("enableTypes")]
        public bool EnableTypes { get; set; }
    }
}