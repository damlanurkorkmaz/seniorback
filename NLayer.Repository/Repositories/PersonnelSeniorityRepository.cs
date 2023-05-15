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
    public class PersonnelSeniorityRepository : GenericRepository <PersonnelSeniority>, IPersonnelSeniorityRepository
    {
        public PersonnelSeniorityRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PersonnelSeniority> GetSinglePersonnelByIdWithProductSeniorityAsync(int seniorityId)
        {
            return await _context.PersonnelSeniorities.Include(x => x.Personnels).Where(x => x.Id == seniorityId).SingleOrDefaultAsync();
        }
    }
}

