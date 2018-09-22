using System.Collections.Generic;
using System.Threading.Tasks;
using HelmesAssignment.DataLayer;
using HelmesAssignment.Entities.Models;
using HelmesAssignment.Interfaces;

using System.Data.Entity;
using System.Linq;

namespace HelmesAssignment.Data.Repositories
{
    public class SubmissionSectorEditRepository : BaseRepository<SubmissionSector>, ISubmissionSectorEditRepository
    {
        public SubmissionSectorEditRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        private async Task<List<SubmissionSector>> GetSubmissionSectorsBySubmission(Submission submission)
        {
            return await _dbContext.SubmissionSectors.Where(ss => ss.Submission.ID == submission.ID).ToListAsync();
        }

        public async Task ClearSectorsFromSubmission(Submission submission)
        {
            var submissionSectors = await GetSubmissionSectorsBySubmission(submission);
            _dbContext.SubmissionSectors.RemoveRange(submissionSectors);
            await _dbContext.SaveChangesAsync();
        }
    }
}
