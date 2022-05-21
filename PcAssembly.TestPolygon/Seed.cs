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
                    Company = "Intel",
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 10000,
                    PowerConsumption = 180,
                    Socket = "1151",
                    Family = "Core i7",
                    Generation = "CoffeLake",
                    Cores = 6,
                    Threads = 12,
                    Frequency = 4.7f,
                };
                var cpu_2 = new CPU()
                {
                    Model = "Intel Core i7-9700K",
                    Company = "Intel",
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 11000,
                    PowerConsumption = 200,
                    Socket = "1151-v2",
                    Family = "Core i7",
                    Generation = "CoffeLakeRefresh",
                    Cores = 8,
                    Threads = 8,
                    Frequency = 4.9f,
                };
                var cpu_3 = new CPU()
                {
                    Model = "Intel Core i9-12900K",
                    Company = "Intel",
                    Type = Domain.Enums.TypeComponent.CPU,
                    Price = 25000,
                    PowerConsumption = 200,
                    Socket = "1700",
                    Family = "Core i9",
                    Generation = "Alder Lake",
                    Cores = 16,
                    Threads = 24,
                    Frequency = 5.2f,
                };

                context.CPUs.Add(cpu_1);
                context.CPUs.Add(cpu_2);
                context.CPUs.Add(cpu_3);
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
                    Company = "Nvidia",
                    Type = Domain.Enums.TypeComponent.GraphicCard,
                    Price = 30000,
                    PowerConsumption = 300,
                    SgRamSize = 11,
                    SgRamType = "GDDR5X",
                    InfoAbout = "This GPU was top at 2019"
                };
                var gp_2 = new GraphicCard()
                {
                    Model = "GTX 3090",
                    Company = "Nvidia",
                    Type = Domain.Enums.TypeComponent.GraphicCard,
                    Price = 120000,
                    PowerConsumption = 350,
                    SgRamSize = 24,
                    SgRamType = "GDDR6X",
                    InfoAbout = "Most Powerful GPU in 2022"
                };
                var gp_3 = new GraphicCard()
                {
                    Model = "GTX 3090Ti",
                    Company = "Nvidia",
                    Type = Domain.Enums.TypeComponent.GraphicCard,
                    Price = 150000,
                    PowerConsumption = 450,
                    SgRamSize = 24,
                    SgRamType = "GDDR6X",
                    InfoAbout = "Most Powerful GPU in 2022"
                };

                context.GraphicCards.Add(gp_1);
                context.GraphicCards.Add(gp_2);
                context.GraphicCards.Add(gp_3);
                await context.SaveChangesAsync();
            }
        }

        public static async Task SeedMotherboards(DataContext context)
        {
            if (!context.Motherboards.Any())
            {
                var motherboard_1 = new Motherboard()
                {
                    Model = "Z390 AORUS MASTER",
                    Company = "Gigabyte",
                    Type = Domain.Enums.TypeComponent.Motherboard,
                    Price = 9500,
                    PowerConsumption = 35,
                    Chipset = "Intel Z390",
                    FormFactor = "ATX",
                    RamType = "DDR4",
                    RamSlots = 4,
                    Socket = "1151-v2",
                    InfoAbout = ""
                };
                var motherboard_2 = new Motherboard()
                {
                    Model = "ASUS ROG Strix Z370-E Gaming",
                    Company = "ASUS",
                    Type = Domain.Enums.TypeComponent.Motherboard,
                    Price = 5000,
                    PowerConsumption = 35,
                    Chipset = "Intel Z370",
                    FormFactor = "ATX",
                    RamType = "DDR4",
                    RamSlots = 4,
                    Socket = "1151",
                    InfoAbout = ""
                };
                var motherboard_3 = new Motherboard()
                {
                   Model = "ASUS ROG MAXIMUS Z690 HERO",
                    Company = "ASUS",
                    Type = Domain.Enums.TypeComponent.Motherboard,
                    Price = 25000,
                    PowerConsumption = 35,
                    Chipset = "Intel Z690",
                    FormFactor = "ATX",
                    RamType = "DDR5",
                    RamSlots = 4,
                    Socket = "1700",
                    InfoAbout = ""
                };

                context.Motherboards.Add(motherboard_1);
                context.Motherboards.Add(motherboard_2);
                context.Motherboards.Add(motherboard_3);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedRams(DataContext context)
        {
            if (!context.Rams.Any())
            {
                var ram_1 = new Ram()
                {
                    Model = "GSkill-3600-cl16",
                    Company = "GSkill",
                    Type = Domain.Enums.TypeComponent.RAM,
                    Price = 9500,
                    PowerConsumption = 5,
                    InfoAbout = "",
                    Count = 2,
                    RamSize = 16,
                    RamType = "DDR4"
                };
                context.Rams.Add(ram_1);
                await context.SaveChangesAsync();
            }
        }
        public static async Task SeedPowerSupplies(DataContext context)
        {
            if (!context.PowerSupplies.Any())
            {
                var powerSupply_1= new PowerSupply()
                {
                    Model = "Seasonic-1000W",
                    Company = "Seasonic",
                    Type = Domain.Enums.TypeComponent.PowerSupply,
                    Price = 12000,
                    PowerConsumption = 1000,
                    InfoAbout = "",
                    Power = 1000
                };
                context.PowerSupplies.Add(powerSupply_1);
                await context.SaveChangesAsync();
            }
        }
    }
}
