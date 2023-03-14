using System.Text.Json.Serialization;

namespace LamyThematique.ViewModels.Web.Models
{
    public class CheckboxItemViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("selected")]
        public bool Selected { get; set; }
    }
}
