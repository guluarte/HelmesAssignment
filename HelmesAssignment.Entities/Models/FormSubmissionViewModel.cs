using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace HelmesAssignment.Entities.Models
{
    public class FormSubmissionViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public MultiSelectList Sectors { get; set; }

        [Required]
        [Display(Name = "Sectors")]
        public IEnumerable<int> SelectedSectors { get; set; }

        [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to terms")]
        [Display(Name = "Agree to terms")]
        public Boolean AgreeToTerms { get; set; }

    }
}