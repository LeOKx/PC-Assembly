using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal;
using PcAssembly.Domain.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.TestPolygon
{
    public class MappingAdvanced
    {
        public static async Task ConcurrencyHandle(DataContext context)
        {
            CPU cpu;
            using (var _context = new DataContext())
            {
                cpu = _context.CPUs.FirstOrDefault();
            }

            Console.WriteLine("Enter CPU Price: ");
            cpu.Price = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter CPU Cores: ");
            //cpu.Cores = int.Parse(Console.ReadLine());

            try
                {
                    context.Entry(cpu).State = EntityState.Modified;
                    //context.Entry(cpu).Entity.Price = 16000;
                //context.CPUs.First().Price = 16000;
                    context.SaveChanges();

                    Console.WriteLine("New Cpu Price Saved");

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine("Handled Concurrency Exeption");
                    //ex.Entries.Single().Reload();

                    //context.SaveChanges();
                    //Console.WriteLine("New Cpu Price Saved After Reload");

                }
            
        }
    }
}
