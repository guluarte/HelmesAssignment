using HelmesAssignment.Entities.Models;
using HelmesAssignment.Entities.Responses;
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

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var vm = TempData["FormSubmissionViewModel"] as FormSubmissionViewModel;

            if (vm == null)
            {
                vm = await GetFormSubmissionViewModel();
            }

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Submit(FormSubmissionViewModel model)
        {
            var vm = await GetFormSubmissionViewModel(model.SelectedSectors);
            vm.Name = model.Name;
            vm.AgreeToTerms = model.AgreeToTerms;

            if (ModelState.IsValid)
            {
 
            }
            TempData["FormSubmissionViewModel"] = vm;
            return RedirectToAction("Index", "Home");
        }

        private async Task<FormSubmissionViewModel> GetFormSubmissionViewModel(IEnumerable<int> selectedSectors = null)
        {
            var getSectorsAsATreeResponse = await _sectorService.GetSectorsAsATree();

            if (!getSectorsAsATreeResponse.Success)
            {
                throw getSectorsAsATreeResponse.Error;
            }

            var formattedSectors = getSectorsAsATreeResponse.Response.ToList();

            formattedSectors.ForEach(s =>
            {
                var prependIdent = new String('\xA0', s.Deep * 6);
                s.Name = $"{prependIdent}{s.Name}";
            });

            return new FormSubmissionViewModel()
            {
                AgreeToTerms = false,
                Name = string.Empty,
                Sectors = new MultiSelectList(formattedSectors, "Id", "Name", selectedSectors)
            }; ;
        }
    }
}