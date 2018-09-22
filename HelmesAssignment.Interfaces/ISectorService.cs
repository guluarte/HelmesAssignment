using HelmesAssignment.Entities.Responses;
using System.Threading.Tasks;

namespace HelmesAssignment.Interfaces
{
    public interface ISectorService
    {
        Task<GetSectorsAsATreeResponse> GetSectorsAsATree();
    }
}
