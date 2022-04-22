using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using System;
using System.Linq;

namespace Project.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProjectContext>>()))
            {
                // Look for any Others parts
                if (context.Others.Any())
                {
                    return;   // DB has been seeded
                }

                context.Others.AddRange(
                    new Others
                    {
                        Name = "Omron g5v-2-h1",
                        Type = "Relay",
                        Quantity = 1,
                        Price = 59
                    },

                    new Others
                    {
                        Name = "Winstar WG12864B-GFH-V",
                        Type = "Display",
                        Quantity = 2,
                        Price = 646
                    },

                    new Others
                    {
                        Name = "HC49U - 1,843 MHz",
                        Type = "Krystal",
                        Quantity = 100,
                        Price = 17
                    },

                    new Others
                    {
                        Name = "TEC1-127090S - 84 W",
                        Type = "Peltier cooler",
                        Quantity = 50,
                        Price = 300
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
