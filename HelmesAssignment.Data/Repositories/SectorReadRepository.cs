using HelmesAssignment.DataLayer;
using HelmesAssignment.Entities.Models;
using HelmesAssignment.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace HelmesAssignment.Entities.Repositories
{
    public class SectorReadRepository : BaseRepository<Sector>,  ISectorReadRepository
    {
        public SectorReadRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Sector>> GetSectors()
        {
            return await _dbContext.Sectors.OrderBy(s => s.Name).ToListAsync();
        }


    }
}