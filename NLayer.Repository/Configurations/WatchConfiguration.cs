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
    internal class WatchConfiguration: IEntityTypeConfiguration <Watch>
    {
        public void Configure(EntityTypeBuilder<Watch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.WatchStartTime).IsRequired().HasColumnType("datetime2"); 
            builder.Property(x => x.WatchEndTime).IsRequired().HasColumnType("datetime2");
            builder.Property(x => x.WeekendWatch).HasColumnType("varchar");
            builder.Property(x => x.WeekWatch).HasColumnType("varchar");


            builder.ToTable("Watches");

            builder.HasMany(x => x.Personnels).WithOne(x => x.Watch).HasForeignKey(x => x.WatchId);



        }
    }
}
