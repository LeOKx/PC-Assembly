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
    public class ComponentConfig : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            //builder.HasOne(c => c.ManufacturerInfo)
            //    .WithOne(m => m.Id)
            //    .HasForeignKey(c => c.InfoId);
            //builder.HasOne<Component>()
            //    .WithOne(c => c.ManufacturerInfo)
            //    .HasForeignKey<Component>(y => y.ManufacturerInfo);

        }
    }
}
