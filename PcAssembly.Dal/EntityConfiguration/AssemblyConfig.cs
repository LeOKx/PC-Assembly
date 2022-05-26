using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcAssembly.Domain;
using PcAssembly.Domain.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcAssembly.Dal.EntityConfiguration
{
    public class AssemblyConfig : IEntityTypeConfiguration<Assembly>
    {
        public void Configure(EntityTypeBuilder<Assembly> builder)
        {
            builder.HasOne(c => c.Cpu)
                .WithMany()
                .HasForeignKey(m => m.CpuId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.GraphicCard)
                .WithMany()
                .HasForeignKey(m => m.GraphicCardId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Motherboard)
                .WithMany()
                .HasForeignKey(m => m.MotherboardId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Ram)
                .WithMany()
                .HasForeignKey(m => m.RamId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.PowerSupply)
                .WithMany()
                .HasForeignKey(m => m.PowerSupplyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
