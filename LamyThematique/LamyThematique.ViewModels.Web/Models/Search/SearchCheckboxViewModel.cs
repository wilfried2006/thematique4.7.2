using System.Text.Json.Serialization;

namespace LamyThematique.ViewModels.Web.Models.Search
{
    public class SearchCheckboxViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }
        
        [JsonPropertyName("checked")]
        public bool Checked { get; set; }
    }
}
