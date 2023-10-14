using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace MovieExplorer.Domain.ApiModels
{
    public class MovieResult
    {
        [JsonProperty("adult")]
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonProperty("backdrop_path")]
        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        [JsonPropertyName("genre_ids")]
        public List<int> GenreIds { get; set; }

        [JsonProperty("id")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonProperty("original_language")]
        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonProperty("overview")]
        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonProperty("popularity")]
        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonProperty("poster_path")]
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonProperty("release_date")]
        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("video")]
        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonProperty("vote_average")]
        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }
    }
}
