using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System.Linq;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PopulateInMemoryDb(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext dbContext)
        {
            if (!dbContext.Platforms.Any())
            {
                dbContext.Platforms.AddRange(
                    new Platform() { Name = "dotnet", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker, Inc.", Cost = "Free" });
            }
        }
    }
}
