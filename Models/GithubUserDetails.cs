using System.Text.Json.Serialization;

namespace WebApplication22.Models
{
    public class GithubUserDetails
    {
        [JsonPropertyName("login")]
        public string UserId { get; set; }
        public string Name { get; set; }

        public string Location { get; set; }

        public string type { get; set; }

        public GithubRepository[] Repositories{ get; set; }
    }
}
