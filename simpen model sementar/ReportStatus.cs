using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ReportStatus // Tabel Lookup
    {
        [Key]
        public int ReportStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Saved, AwaitingTechReview, AwaitingSalesReview, Approved, Rejected
        public virtual ICollection<SurveyReportInstance> SurveyReportInstances { get; set; } = new HashSet<SurveyReportInstance>();
        public virtual ICollection<MeetingReportInstance> MeetingReportInstances { get; set; } = new HashSet<MeetingReportInstance>();
    }
}