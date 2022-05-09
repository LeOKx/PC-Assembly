using Microsoft.EntityFrameworkCore;
using PcAssembly.Dal.EntityConfiguration;
using PcAssembly.Domain;
using PcAssembly.Domain.Auth;
using PcAssembly.Domain.Components;

namespace PcAssembly.Dal
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Component> Components { get; set; }
        public virtual DbSet<CPU> CPUs { get; set; }
        public DbSet<GraphicCard> GraphicCards { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<PowerSupply> PowerSupplies { get; set; }
        //public DbSet<ManufacturerInfo> ManufacturerInfos { get; set; }
        public DbSet<Assembly> Assemblies{ get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UsersProfiles { get; set; }
        //public DbSet<CompanyList> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AssemblyConfig());
            modelBuilder.ApplyConfiguration(new SavedAssemblyConfig());

            //modelBuilder.ApplyConfiguration(new ComponentConfig());
            //modelBuilder.Entity<CPU>();
            //modelBuilder.Entity<GraphicCard>();

            modelBuilder.Entity<CPU>().ToTable("CPUs");
            modelBuilder.Entity<GraphicCard>().ToTable("GraphicCards");
            modelBuilder.Entity<Motherboard>().ToTable("Motherboards");
            modelBuilder.Entity<Ram>().ToTable("Rams");
            modelBuilder.Entity<PowerSupply>().ToTable("PowerSupplyes");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                @"Server=1080TI-I7-8700K\SQLEXPRESS;Database=pc-assembly;Trusted_Connection=True; MultipleActiveResultSets = true");
        }

    }
}
