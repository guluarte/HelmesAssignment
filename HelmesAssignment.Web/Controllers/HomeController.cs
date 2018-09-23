using HelmesAssignment.Entities.Models;
using HelmesAssignment.Interfaces;

using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HelmesAssignment.Constants;
using HelmesAssignment.Entities.Requests;

namespace HelmesAssignment.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISectorService _sectorService;
        private readonly ISubmissionService _submissionService;

        public HomeController(
            ISectorService sectorService,
            ISubmissionService submissionService
        )
        {
            _sectorService = sectorService;
            _submissionService = submissionService;
        }

        /// <summary>
        /// Clears the session and the session cookie
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult New()
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction(Constants.Constants.HomeIndexAction, Constants.Constants.HomeController);
        }

        /// <summary>
        /// Main page, displays the submission form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var vm = TempData[Constants.Constants.FormSubmissionViewModel] as FormSubmissionViewModel;

            if (vm == null)
            {
                var currentSessionSubmission = await _submissionService.GetSubmissionBySessionId(GetCurrentSessionId);

                if (currentSessionSubmission != null)
                {
                    var selectedSectorsId = currentSessionSubmission.SubmissionSectors.Select(ss => ss.Sector.ID);
                    vm = await GetFormSubmissionViewModel(selectedSectorsId);

                    vm.Name = currentSessionSubmission.Name;
                    vm.AgreeToTerms = currentSessionSubmission.AgreeToTerms;
                }
                else
                {
                    vm = await GetFormSubmissionViewModel();
                }
            }

            return View(vm);
        }

        /// <summary>
        /// Saves the submission, if there is an error shows the form with the validation
        /// errors
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Submit(FormSubmissionViewModel model)
        {
            var vm = await GetFormSubmissionViewModel(model.SelectedSectors);
            vm.SelectedSectors = model.SelectedSectors;
            vm.Name = model.Name;
            vm.AgreeToTerms = model.AgreeToTerms;

            if (ModelState.IsValid)
            {
                var createRequest = new SubmissionCreateOrUpdateRequest
                {
                    SessionId = GetCurrentSessionId,
                    FormSubmissionViewModel = vm
                };

                var response = await _submissionService.CreateOrUpdateSubmission(createRequest);

                if (response.Success)
                {
                    TempData[Constants.Constants.FlashMessage] = new FlashMessage
                    {
                        Message = StringResources.FormSavedSuccessMessage,
                        MessageType = MessageType.Success
                    };
                }
                else
                {
                    TempData[Constants.Constants.FlashMessage] = new FlashMessage
                    {
                        Message = StringResources.FormSavedErrorMessage,
                        MessageType = MessageType.Danger
                    };

                }

                return RedirectToAction(Constants.Constants.HomeIndexAction, Constants.Constants.HomeController);

            }

            TempData[Constants.Constants.FormSubmissionViewModel] = vm;
            return RedirectToAction(Constants.Constants.HomeIndexAction, Constants.Constants.HomeController);
        }

        /// <summary>
        /// Builds the form view model
        /// </summary>
        /// <param name="selectedSectors"></param>
        /// <returns></returns>
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
                // inserts &nbsp;
                var prependIdent = new string('\xA0', s.Deep * 6);
                s.Name = $"{prependIdent}{s.Name}";
            });

            return new FormSubmissionViewModel
            {
                AgreeToTerms = false,
                Name = string.Empty,
                Sectors = new MultiSelectList(formattedSectors, "Id", "Name", selectedSectors)
            }; ;
        }
    }
}