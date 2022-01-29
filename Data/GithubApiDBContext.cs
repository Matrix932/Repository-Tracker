using Microsoft.EntityFrameworkCore;
using WebApplication22.Models;

namespace WebApplication22.Data
{
    public class GithubApiDBContext : DbContext
    {
        public GithubApiDBContext(DbContextOptions<GithubApiDBContext> options) : base(options)
        {
        }

        public DbSet<GithubUserDetails> GithubUserDetails { get; set; }
        public DbSet<GithubRepository> GithubRepositories { get; set; }
    }
}