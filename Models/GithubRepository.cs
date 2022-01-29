using System.Text.Json.Serialization;

namespace WebApplication22.Models
{
    public class GithubRepository
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string Language { get; set; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; }

        [JsonPropertyName("watchers_count")]
        public int WatchersCount { get; set; }
    }
}