using HelmesAssignment.Entities.Models;
using HelmesAssignment.Entities.Responses;
using HelmesAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelmesAssignment.Services
{
    public class SectorsService : ISectorService
    {
        private readonly ISectorReadRepository _sectorReadRepository;

        public SectorsService(ISectorReadRepository sectorReadRepository)
        {
            _sectorReadRepository = sectorReadRepository;
        }

        private IEnumerable<SectorViewModel> GetChildren(Sector parentSector, int deep)
        {
            deep++;

            if (parentSector.Children == null)
            {
                yield return null;
            }

            var children = parentSector.Children.OrderBy(s => s.Name);
            foreach (var rootSector in children)
            {
                yield return new SectorViewModel(rootSector, deep);
                var childSectors = GetChildren(rootSector, deep);
                foreach (var childSector in childSectors)
                {
                    yield return childSector;
                }
            }
        }

        public async Task<GetSectorsAsATreeResponse> GetSectorsAsATree()
        {
            var sectorsTree = new List<SectorViewModel>();

            var sectors = await _sectorReadRepository.GetSectors();

            var rootSectors = sectors.Where(s => s.ParentSector == null).ToList();

            foreach (var rootSector in rootSectors)
            {
                sectorsTree.Add(new SectorViewModel(rootSector, 0));
                var childSectors = GetChildren(rootSector, 0);
                foreach (var childSector in childSectors)
                {
                    sectorsTree.Add(childSector);
                }
            }

            return new GetSectorsAsATreeResponse
            {
                Error = null,
                Success = true,
                Response = sectorsTree
            };

        }
    }
}
