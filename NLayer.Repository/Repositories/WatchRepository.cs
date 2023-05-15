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
    public class WatchRepository : GenericRepository<Watch>, IWatchRepository
    {
        public WatchRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Watch> GetSingleWatchByIdWithPersonnelAsync(int watchId)
        {
            return await _context.Watches.Include(x => x.Personnels).Where(x => x.Id == watchId).SingleOrDefaultAsync();

        }
    }
}
