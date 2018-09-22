using HelmesAssignment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HelmesAssignment.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISectorService _sectorService;

        public HomeController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        public async Task<ActionResult> Index()
        {
            var sectorsViewModels = await _sectorService.GetSectorsAsATree();
            return View();
        }
    }
}