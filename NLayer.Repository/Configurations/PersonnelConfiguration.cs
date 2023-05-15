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
    internal class PersonnelConfiguration: IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200); 

            builder.ToTable("Personnels");

            builder.HasOne(x => x.Watch).WithMany(x => x.Personnels).HasForeignKey(x => x.WatchId);
            builder.HasOne(x => x.PersonnelSeniority).WithMany(x => x.Personnels).HasForeignKey(x => x.PersonnelSeniorityId);

        }
    }
}
