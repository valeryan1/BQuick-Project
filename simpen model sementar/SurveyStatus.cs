using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyStatus // Tabel Lookup
    {
        [Key]
        public int SurveyStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Not Yet, Waiting Tech Approval, Approved, On Progress, Report Submitted, etc.
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; } = new HashSet<SurveyRequest>();
    }
}