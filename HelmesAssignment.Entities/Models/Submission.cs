using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelmesAssignment.Entities.Models
{
    public class Submission
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string SessionId { get; set; }
        public Boolean AgreeToTerms { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}