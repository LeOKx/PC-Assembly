using PcAssembly.Dal;
using PcAssembly.Domain.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.TestPolygon
{
    public class Seed
    {
        public static async Task SeedCPUs(DataContext context)
        {
            if (!context.CPUs.Any())
            {
                var cpu_1 = new CPU()
                {
                    Model = "Intel Core i7-8700K",
                    Company = Domain.Enums.Company.Intel,
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 10000,
                    PowerConsumption = 180,
                    Socket = Domain.Enums.Socket.Socket_1151,
                    Family = Domain.Enums.CpuFamily.Core_i7,
                    Generation = Domain.Enums.CpuGeneration.CoffeLake,
                    Cores = 6,
                    Threads = 12,
                    Frequency = 4.7f,
                };
                var cpu_2 = new CPU()
                {
                    Model = "Intel Core i7-9700K",
                    Company = Domain.Enums.Company.Intel,
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 11000,
                    PowerConsumption = 200,
                    Socket = Domain.Enums.Socket.Socket_1151_V2,
                    Family = Domain.Enums.CpuFamily.Core_i7,
                    Generation = Domain.Enums.CpuGeneration.CoffeLakeRefresh,
                    Cores = 8,
                    Threads = 8,
                    Frequency = 4.9f,
                };

                context.CPUs.Add(cpu_1);
                context.CPUs.Add(cpu_2);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedGraphicCards(DataContext context)
        {
            if (!context.GraphicCards.Any())
            {
                var gp_1 = new GraphicCard()
                {
                    Model = "GTX 1080Ti",
                    Company = Domain.Enums.Company.Nvidia,
                    Type = Domain.Enums.TypeComponent.GraphicCard,
                    Price = 30000,
                    PowerConsumption = 300,
                    SgRamSize = 11,
                    SgRamType = Domain.Enums.SgRamType.GDDR5X,
                    About = "This GPU was top at 2019"
                };
                var gp_2 = new GraphicCard()
                {
                    Model = "GTX 3090",
                    Company = Domain.Enums.Company.Nvidia,
                    Type = Domain.Enums.TypeComponent.GraphicCard,
                    Price = 120000,
                    PowerConsumption = 350,
                    SgRamSize = 24,
                    SgRamType = Domain.Enums.SgRamType.GDDR6X,
                    About = "Most Powerful GPU in 2022"
                };
                var gp_3 = new GraphicCard()
                {
                    Model = "GTX 3090Ti",
                    Company = Domain.Enums.Company.Nvidia,
                    Type = Domain.Enums.TypeComponent.GraphicCard,
                    Price = 150000,
                    PowerConsumption = 450,
                    SgRamSize = 24,
                    SgRamType = Domain.Enums.SgRamType.GDDR6X,
                    About = "Most Powerful GPU in 2022"
                };

                context.GraphicCards.Add(gp_1);
                context.GraphicCards.Add(gp_2);
                context.GraphicCards.Add(gp_3);
                await context.SaveChangesAsync();
            }
        }
    }
}
