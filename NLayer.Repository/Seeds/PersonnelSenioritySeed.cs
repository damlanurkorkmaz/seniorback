using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class PersonnelSenioritySeed : IEntityTypeConfiguration<PersonnelSeniority>
    {
        public void Configure(EntityTypeBuilder<PersonnelSeniority> builder)
        {
            builder.HasData(
                new PersonnelSeniority { Id = 1, PersonnelId=1, SeniorityType = "High"},
                new PersonnelSeniority { Id = 2, PersonnelId = 2, SeniorityType = "Mid" },
                new PersonnelSeniority { Id = 3, PersonnelId = 3, SeniorityType = "Junior" }

                );
        }
    }
}
