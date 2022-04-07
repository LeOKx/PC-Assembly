using PcAssembly.Dal;
using PcAssembly.Domain.Components;

namespace PcAssembly.TestPolygon
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var dbContext = new DataContext();
            //await MappingAdvanced.ConcurrencyHandle(dbContext);
            await Seed.SeedCPUs(dbContext);
            await Seed.SeedGraphicCards(dbContext);
            await Queries.GetAllComponents(dbContext);
            await Queries.GetAllCpus(dbContext);
        }

        
    }
    
}