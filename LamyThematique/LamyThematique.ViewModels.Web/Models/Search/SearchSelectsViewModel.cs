using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LamyThematique.ViewModels.Web.Models.Search
{
    public class SearchSelectsViewModel
    {
        [JsonPropertyName("items")]
        public List<SearchSelectItemViewModel> Items { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
