using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class Personnel : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public int PersonnelSeniorityId { get; set; }
        public int WatchId { get; set; }
        public string UserId { get; set; }
        public Watch Watch { get; set; }
        public PersonnelSeniority PersonnelSeniority { get; set; }
    }
}
