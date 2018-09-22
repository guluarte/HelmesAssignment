using System;
using System.ComponentModel.DataAnnotations;

namespace HelmesAssignment.Entities.Models
{
    public class SubmissionSector
    {
        [Key]
        public Guid Id { get; set; }
        public Submission Submission { get; set; }
        public Sector Sector { get; set; }
    }
}