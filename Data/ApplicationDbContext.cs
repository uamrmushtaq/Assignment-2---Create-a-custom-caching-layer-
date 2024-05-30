
using Microsoft.EntityFrameworkCore;
using CentralizedCachingAPI.Models;
namespace CentralizedCachingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CachedResponse> CachedResponses { get; set; }
    }
}

