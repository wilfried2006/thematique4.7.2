using System.Text.Json.Serialization;

namespace LamyThematique.ViewModels.Web.Models.Search
{
    public class SearchContentResultItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("badge")]
        public string Badge { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }
    }
}
