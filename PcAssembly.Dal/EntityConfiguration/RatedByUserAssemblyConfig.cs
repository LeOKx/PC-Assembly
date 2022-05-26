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
    public class RatedByUserAssemblyConfig : IEntityTypeConfiguration<RatedByUserAssembly>
    {
        public void Configure(EntityTypeBuilder<RatedByUserAssembly> builder)
        {
            builder.HasKey(t => new { t.UserId, t.AssemblyId });
                                                
                                                
        }
    }
}
