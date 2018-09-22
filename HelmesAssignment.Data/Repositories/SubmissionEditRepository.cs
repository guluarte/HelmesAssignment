using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HelmesAssignment.DataLayer;
using HelmesAssignment.Entities.Models;
using HelmesAssignment.Interfaces;

using System.Data.Entity;
using System.Linq;

namespace HelmesAssignment.Data.Repositories
{
    public class SubmissionEditRepository : BaseRepository<Submission>, ISubmissionEditRepository
    {
        public SubmissionEditRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Submission> GetSubmissionBySessionId(string sessionId)
        {
            return await _dbContext.Submissions
                .Include(s => s.SubmissionSectors)
                .FirstOrDefaultAsync(s => s.SessionId == sessionId);
        }
    }
}