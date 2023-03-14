using System.Text.Json.Serialization;

namespace LamyThematique.ViewModels.Web.Models
{
    public class SelectListItemViewModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("selected")]
        public bool Selected { get; set; }


        [JsonPropertyName("parentId")]
        public int ParentId { get; set; }
    }
}
