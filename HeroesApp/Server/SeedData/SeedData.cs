using HeroesApp.Server.Data;
using HeroesApp.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace HeroesApp.Server.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any comic
                if (context.Comics.Any())
                {
                    return;   // DB has been seeded
                }

                context.Comics.AddRange(
                    new Comic {Name = "Marvel" },
                    new Comic {Name = "DC" }
                );

                context.SaveChanges();

                if (context.Heroes.Any())
                {
                    return;   // DB has been seeded
                }

                context.Heroes.AddRange(
                    new Hero {FirstName = "Peter", LastName = "Parker", HeroName = "Spiderman", ComicId = 1 },
                    new Hero {FirstName = "Bruce", LastName = "Wayne", HeroName = "Batman", ComicId = 2 }
                );


                context.SaveChanges();
            }
        }
    }
}