using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Watch: BaseEntity
    {
        public DateTimeOffset WatchStartTime { get; set; }
        public DateTimeOffset WatchEndTime { get; set; }
        public DateTime WatchDate { get; set; }
        public string WeekendWatch { get; set; } = string.Empty;
        public string WeekWatch { get; set; } = string.Empty;
        public int PersonnelId { get; set; }

        public ICollection<Personnel> Personnels { get; set; }
        public CanceledWatch CanceledWatches { get; set; }

    }
}
