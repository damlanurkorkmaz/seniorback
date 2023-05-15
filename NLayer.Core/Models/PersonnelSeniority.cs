using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Models
{
    public class PersonnelSeniority
    {
        public int Id { get; set; }
        public string SeniorityType { get; set; }

        public int PersonnelId { get; set; }

        public ICollection<Personnel> Personnels { get; set; }
    }
}
