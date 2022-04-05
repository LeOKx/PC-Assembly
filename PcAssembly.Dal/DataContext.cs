using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.EntityConfiguration;
using PcAssembly.Domain;
using PcAssembly.Domain.Auth;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal
{
    public class DataContext : DbContext
    {
        //public DataContext()
        //{
        //}

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DbSet<Component> Components { get; set; }
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<GraphicCard> GraphicCards { get; set; }
        //public DbSet<ManufacturerInfo> ManufacturerInfos { get; set; }
        public DbSet<Assembly> Assemblies{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AssemblyConfig());
            modelBuilder.ApplyConfiguration(new SavedAssemblyConfig());

            //modelBuilder.Entity<CPU>();
            //modelBuilder.Entity<GraphicCard>();
        }


    }
}
