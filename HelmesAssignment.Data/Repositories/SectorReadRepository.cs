using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using HelmesAssignment.DataLayer;
using HelmesAssignment.Entities.Models;
using HelmesAssignment.Interfaces;

namespace HelmesAssignment.Data.Repositories
{
    public class SectorReadRepository : BaseRepository<Sector>,  ISectorReadRepository
    {
        public SectorReadRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<IEnumerable<Sector>> GetSectors()
        {
            return await _dbContext.Sectors
                   .Include(s => s.Children)
                   .OrderBy(s => s.Name)
                   .ToListAsync();
        }

        public async Task<List<Sector>> GetSectorsByIds(IEnumerable<int> sectors)
        {
            return await _dbContext.Sectors.Where(s => sectors.Contains(s.ID)).ToListAsync();
        }


    }
}
