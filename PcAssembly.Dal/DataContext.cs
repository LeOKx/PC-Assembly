using Microsoft.EntityFrameworkCore;
using PcAssembly.Domain;

namespace PcAssembly.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CPU> CPUs { get; set; }
    }
}
