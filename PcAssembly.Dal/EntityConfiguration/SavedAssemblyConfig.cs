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
    public class SavedAssemblyConfig : IEntityTypeConfiguration<SavedAssemblies>
    {
        public void Configure(EntityTypeBuilder<SavedAssemblies> builder)
        {
            builder.HasKey(t => new { t.UserId, t.AssemblyId });
            builder.HasOne(t => t.Assembly)
                .WithMany(t => t.SavedAssemblies)
                .HasForeignKey(t => t.AssemblyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t => t.User)
                .WithMany(t => t.SavedAssemblies)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
