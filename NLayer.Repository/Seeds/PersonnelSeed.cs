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
    internal class PersonnelSeed : IEntityTypeConfiguration<Personnel>
    {
        public void Configure(EntityTypeBuilder<Personnel> builder)
        {
            builder.HasData(
                new Personnel { Id = 1, WatchId = 1, Name = "Damla Nur", Surname = "Korkmaz", Title = "Uzman", PersonnelSeniorityId = 1 },
                new Personnel { Id = 2, WatchId = 1, Name = "Eda Nur", Surname = "Korkmaz", Title = "Uzman", PersonnelSeniorityId = 2 },
                new Personnel { Id = 3, WatchId = 1, Name = "Elif", Surname = "Korkmaz", Title = "Uzman", PersonnelSeniorityId = 3 },
                new Personnel { Id = 4, WatchId = 1, Name = "Semih Berkay" , Surname = "Korkmaz", Title = "Uzman", PersonnelSeniorityId = 1 }
            );

        }
    }
}
