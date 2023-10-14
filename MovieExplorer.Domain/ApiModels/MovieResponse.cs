using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieExplorer.Domain.ApiModels
{
    public class MovieResponse
    {
        [JsonProperty("page")]
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonProperty("results")]
        [JsonPropertyName("results")]
        public List<MovieResult> Movies { get; set; }

        [JsonProperty("total_pages")]
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
