using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AdContext(
                serviceProvider.GetRequiredService<DbContextOptions<AdContext>>()))
            {
                // Look for any movies.
                if (context.Ads.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.AddRange(
                     new Category
                     {
                         Name = "Consumering"
                     },
                     new Category
                     {
                         Name = "Dienst"
                     },
                     new Category
                     {
                         Name = "Product"
                     },
                     new Category
                     {
                         Name = "Politiek"
                     }

                   
                );
                context.SaveChanges();
            }
        }
    }
}