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
    internal class WatchSeed : IEntityTypeConfiguration<Watch>
    {
        public void Configure(EntityTypeBuilder<Watch> builder)
        {
            builder.HasData(
                new Watch
                {
                    Id = 1,
                    WatchStartTime = new DateTimeOffset(2023, 05, 04, 18, 0, 0, TimeSpan.FromHours(3)),
                    WatchEndTime = new DateTimeOffset(2023, 05, 04, 10, 0, 0, TimeSpan.FromHours(3)),
                    PersonnelId = 1
                });
                
        }
    }
}
