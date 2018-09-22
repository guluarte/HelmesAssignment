using HelmesAssignment.Entities.Models;

namespace HelmesAssignment.Entities.Requests
{
    public class SubmissionCreateOrUpdateRequest
    {
        public FormSubmissionViewModel FormSubmissionViewModel { get; set; }
        public string SessionId { get; set; }
    }
}