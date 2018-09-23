using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using HelmesAssignment.Constants;

namespace HelmesAssignment.Entities.Models
{
    public class FormSubmissionViewModel
    {
        [Required]
        [Display(Name = "FormSubmissionViewModelName", ResourceType = typeof(StringResources))]
        public string Name { get; set; }

        public MultiSelectList Sectors { get; set; }

        [Required]
        [Display(Name = "FormSubmissionViewModelSectors", ResourceType = typeof(StringResources))]
        public IEnumerable<int> SelectedSectors { get; set; }

        [Display(Name = "FormSubmissionViewModelAgreeToTerms", ResourceType = typeof(StringResources))]
        [Range(typeof(bool), "true", "true", ErrorMessageResourceType = typeof(StringResources), ErrorMessageResourceName = "FormSubmissionViewModelAgreeToTermsErrorMessage")]
        public bool AgreeToTerms { get; set; }

    }
}