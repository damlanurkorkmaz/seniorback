using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ScheduleRepository : GenericRepository<Personnel>, IPersonnelRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context)
        {

        }
        public List<string> GenerateSchedule(List<string> personnel, int totalDays, int minDaysBetweenShifts)
        {
            List<string> schedule = new List<string>();

            // Algoritma kodunu buraya ekleyin
            // ...

            return schedule;
        }
    }
    
}
