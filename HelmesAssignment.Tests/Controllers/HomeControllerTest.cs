using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelmesAssignment.Web;
using HelmesAssignment.Web.Controllers;
using System.Threading.Tasks;

namespace HelmesAssignment.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task Index()
        {
            // Arrange
            HomeController controller = new HomeController(null, null);

            // Act
            ViewResult result = await controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
