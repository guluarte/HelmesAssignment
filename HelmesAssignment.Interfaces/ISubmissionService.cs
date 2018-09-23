using System.Threading.Tasks;
using HelmesAssignment.Entities.Models;
using HelmesAssignment.Entities.Requests;
using HelmesAssignment.Entities.Responses;

namespace HelmesAssignment.Interfaces
{
    public interface ISubmissionService
    {
        Task<Submission> GetSubmissionBySessionId(string sessionId);
        Task<SubmissionCreateOrUpdateResponse> CreateOrUpdateSubmission(SubmissionCreateOrUpdateRequest request);
    }
}
