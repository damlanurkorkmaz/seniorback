using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Configurations
{
    internal class CanceledWatchConfiguration: IEntityTypeConfiguration<CanceledWatch>
    {
        public void Configure(EntityTypeBuilder<CanceledWatch> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CanceledWatchTime).IsRequired().HasColumnType("datetime2");


            builder.ToTable("CanceledWatches");

            builder.HasMany(x => x.Watches).WithOne(x => x.CanceledWatches).HasForeignKey(x => x.PersonnelId);
        }
    }
}
