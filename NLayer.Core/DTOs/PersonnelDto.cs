using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class PersonnelDto: BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string PersonnelSeniorityId { get; set; }
        public int WatchId { get; set; }
    }
}
