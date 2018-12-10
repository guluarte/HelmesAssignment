using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Threading.Tasks;
using HelmesAssignment.Interfaces;
using Moq;

using HelmesAssignment.Services;
using HelmesAssignment.Entities.Models;

namespace HelmesAssignment.Tests.Services
{
    [TestClass]
    public class SectorServiceTest
    {
        private SectorsService SectorsService { get; set; }

        [TestInitialize]
        public void TestInit()
        {
            var mockISectorReadRepository = new Mock<ISectorReadRepository>();

            var sectorWithChildren = new Sector(4, "WithChildren")
            {
                Children = new List<Sector> { new Sector(5, "Children")
                {
                    Children =  new List<Sector> { new Sector(6, "ChildrenOfChildren")}
                }}
            };

            var sampleSectors = new List<Sector>
            {
                new Sector(1, "Test"),
                new Sector(2, "Test2"),
                new Sector(3, "Test3"),
                sectorWithChildren
            };

            mockISectorReadRepository.Setup(sr => sr.GetSectors())
                .Returns(Task.FromResult(sampleSectors.AsEnumerable()));

            SectorsService = new SectorsService(mockISectorReadRepository.Object);
        }

        [TestMethod]
        public async Task GetSectorsAsATree()
        {
            var getSectors = (await SectorsService.GetSectorsAsATree()).Response.ToList();

            Assert.AreEqual(getSectors.Count, 6);
        }

        [TestMethod]
        public async Task SectorChildrenAsDeepOfOne()
        {
            var getSectors = (await SectorsService.GetSectorsAsATree()).Response.ToList();

            var childSector = getSectors.FirstOrDefault(s => s.Name.Equals("Children"));

            Assert.AreEqual(childSector.Deep, 1);
        }

        [TestMethod]
        public async Task SectorChildrenChildrenAsDeepOfTow()
        {
            var getSectors = (await SectorsService.GetSectorsAsATree()).Response.ToList();

            var childSector = getSectors.FirstOrDefault(s => s.Name.Equals("ChildrenOfChildren"));

            Assert.AreEqual(childSector.Deep, 2);
        }
    }
}
