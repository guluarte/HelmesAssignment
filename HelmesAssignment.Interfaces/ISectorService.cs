using HelmesAssignment.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelmesAssignment.Interfaces
{
    public interface ISectorService
    {
        Task<IEnumerable<SectorViewModel>> GetSectorsAsATree();
    }
}
