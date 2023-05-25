using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class WatchDto: BaseDto
    {
        public DateTimeOffset WatchStartTime { get; set; }
        public DateTimeOffset WatchEndTime { get; set; }
        public DateTime WatchDate { get; set; }
        public string WeekendWatch { get; set; }
        public string WeekWatch { get; set; }
        public int? PersonnelId { get; set; }
        public string PersonnelName { get; set; }
    }
}
