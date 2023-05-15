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
    internal class CanceledWatchSeed : IEntityTypeConfiguration<CanceledWatch>
    {
        public void Configure(EntityTypeBuilder<CanceledWatch> builder)
        {
            builder.HasData(
                 new CanceledWatch { Id = 1, WatchId = 1, PersonnelId = 1,
                     CanceledWatchTime = new DateTimeOffset(2023, 05, 04, 18, 0, 0, TimeSpan.FromHours(3)) },
                 new CanceledWatch { Id = 2, WatchId = 2, PersonnelId = 2,
                     CanceledWatchTime = new DateTimeOffset(2023, 05, 04, 12, 30, 0, TimeSpan.FromHours(3)) }
                );
        }
    }
}
