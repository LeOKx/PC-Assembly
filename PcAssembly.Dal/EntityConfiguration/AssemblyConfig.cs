using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcAssembly.Domain;
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
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Cpu)
                .IsRequired();

        }
    }
}
