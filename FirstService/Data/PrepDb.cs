using FirstService.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace FirstService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                seedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void seedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("-Seeding data-");
                context.Platforms.AddRange(
                    new Platform() { Name = ".Net" , Publisher = "Microsoft" , Cost="Free"},
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernates", Publisher = "Cloud Native", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("-We already data-");
            }
        }
    }
}
