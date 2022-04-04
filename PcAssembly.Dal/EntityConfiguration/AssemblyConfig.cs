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

        }
    }
}
