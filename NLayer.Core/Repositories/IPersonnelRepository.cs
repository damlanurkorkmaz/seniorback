using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Repositories
{
    public interface IPersonnelRepository: IGenericRepository<Personnel>
    {
        //Task<List<Personnel>> GetPersonnelsWithWatch(); 
        //Task<Personnel> GetPersonnelsWithPersonnelSeniority(int personnelSeniorityId);
        //Task<List<Personnel>> GetPersonnelsByWatchStartTime(int id);

    }
}
