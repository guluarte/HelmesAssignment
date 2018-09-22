using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelmesAssignment.Entities.Requests;
using HelmesAssignment.Entities.Responses;

namespace HelmesAssignment.Interfaces
{
    public interface ISubmissionService
    {
        Task<SubmissionCreateOrUpdateResponse> CreateOrUpdateSubmission(SubmissionCreateOrUpdateRequest request);
    }
}
