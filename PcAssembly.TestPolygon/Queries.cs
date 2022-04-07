using PcAssembly.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.TestPolygon
{
    public class Queries
    {
        public static async Task GetAllCpus(DataContext context)
        {
            var query = from components in context.Components
                        join cpus in context.CPUs
                        on components.Id equals cpus.Id
                        where cpus.Type == Domain.Enums.TypeComponent.CPU
                        select new { cpus};
            var result = query.ToList();
            result.ForEach(x => Console.WriteLine(x.cpus.Model+" "+x.cpus.Frequency));

            var query2 = from cpus in context.CPUs
                    select cpus;
            var result2 = query2.ToList();
            result2.ForEach(x => Console.WriteLine(x.Model + " " + x.Frequency));
        }

        public static async Task GetAllComponents(DataContext context)
        {
            var result = context.Components.ToList();
            result.ForEach(x => Console.WriteLine($"Type: {x.Type}\n" +
                                                  $"Model: {x.Model}\n" +
                                                  $"Company: {x.Company}\n" +
                                                  $"PowerConsumption: {x.PowerConsumption}\n" +
                                                  $"Price: {x.Price}\n"));
        }
    }
}
