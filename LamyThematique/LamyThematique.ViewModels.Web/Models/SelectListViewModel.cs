using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace LamyThematique.ViewModels.Web.Models
{
    public class SelectListViewModel
    {
        public int Id { get; set; }

        [JsonPropertyName("items")]
        public IEnumerable<SelectListItemViewModel> Items { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
