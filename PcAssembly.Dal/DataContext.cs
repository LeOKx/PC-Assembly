using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.EntityConfiguration;
using PcAssembly.Domain;

namespace PcAssembly.Dal
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CPU> CPUs { get; set; }
        public DbSet<ManufacturerInfo> ManufacturerInfos { get; set; }
        public DbSet<Assembly> Assemblies{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new AssemblyConfig());
            //modelBuilder.ApplyConfiguration(new ComponentConfig());
        }


    }
}
