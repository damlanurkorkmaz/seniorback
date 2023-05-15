using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class PersonnelRepository: GenericRepository<Personnel>, IPersonnelRepository
    {
        public PersonnelRepository(AppDbContext context) : base(context)
        {
        }

        //public async Task<List<Personnel>> GetPersonnelsWithWatch()
        //{
        //    //eager loading
        //    return await _context.Personnels.Include(x => x.Watch).ToListAsync();
        //}
        //public async Task<Personnel> GetPersonnelsWithPersonnelSeniority(int personnelSeniorityId)
        //{
        //    //eager loading
        //    //return await _context.Personnels.Include(x => x.Watch).ToListAsync();
        //    return await _context.Personnels.Include(x => x.PersonnelSeniorityId).Where(x => x.Id == personnelSeniorityId).SingleOrDefaultAsync();

        //}
        //public async Task<List<Personnel>> GetPersonnelsByWatchStartTime(int watchId)
        //{
        //    //eager loading
        //    return await _context.Personnels.Include(x => x.Watch).ToListAsync();
        //}
        
    }

}
