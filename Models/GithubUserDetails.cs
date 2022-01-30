using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplication22.Models
{
    public class GithubUserDetails
    {
        [Key]
        [JsonPropertyName("login")]
        public string UserId { get; set; }

        public GithubUserDetails(string userId, string name, string location, string type, GithubRepository[] repositories)
        {
            UserId = userId;
            Name = name;
            Location = location;
            this.type = type;
            Repositories = repositories;
        }

        public GithubUserDetails()
        {
        }

        public string Name { get; set; }

        public string Location { get; set; }

        public string type { get; set; }

        public GithubRepository[] Repositories { get; set; }
    }
}