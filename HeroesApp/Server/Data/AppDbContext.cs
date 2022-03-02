using HeroesApp.Shared;
using Microsoft.EntityFrameworkCore;

namespace HeroesApp.Server.Data
{
    public class AppDbContext :  DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
