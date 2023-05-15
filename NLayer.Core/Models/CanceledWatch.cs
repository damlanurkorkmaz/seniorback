using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class CanceledWatch: BaseEntity
    {
        [Column(TypeName = "datetimeoffset")]
        public DateTimeOffset CanceledWatchTime { get; set; }
        public int WatchId { get; set; }
        public int PersonnelId { get; set; }
        public ICollection <Watch> Watches { get; set; }
    }
}
