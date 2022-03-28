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
    public class ManufacturerInfoConfig : IEntityTypeConfiguration<ManufacturerInfo>
    {
        public void Configure(EntityTypeBuilder<ManufacturerInfo> builder)
        {
            //builder.HasOne<Component>(m => m.Id)
            //    .WithOne(c => c.InfoId)
            //    .HasForeignKey<Component>(y => y.ManufacturerInfo);

        }
    }
}
