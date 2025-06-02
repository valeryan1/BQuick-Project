using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class PICApprovalStatus // Tabel Lookup
    {
        [Key]
        public int PICApprovalStatusID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } // Pending, Accepted, Rejected
        public virtual ICollection<SurveyPIC> SurveyPICs { get; set; } = new HashSet<SurveyPIC>();
        public virtual ICollection<MeetingPIC> MeetingPICs { get; set; } = new HashSet<MeetingPIC>();
    }
}