using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyReportInstance
    {
        [Key]
        public int SurveyReportInstanceID { get; set; }
        public int SurveyInstanceID { get; set; }
        [ForeignKey("SurveyInstanceID")]
        public virtual SurveyInstance SurveyInstance { get; set; }

        public int ReportMasterID { get; set; }
        [ForeignKey("ReportMasterID")]
        public virtual ReportMaster ReportMaster { get; set; }

        public string ReportContent { get; set; } // JSON/XML/HTML atau path ke file
        public int GeneratedByUserID { get; set; }
        [ForeignKey("GeneratedByUserID")]
        public virtual User GeneratedByUser { get; set; }
        public DateTime GeneratedTimestamp { get; set; } = DateTime.UtcNow;

        public int ReportStatusID { get; set; } // FK ke ReportStatus
        [ForeignKey("ReportStatusID")]
        public virtual ReportStatus ReportStatus { get; set; }

        public int? TechManagerReviewerID { get; set; }
        [ForeignKey("TechManagerReviewerID")]
        public virtual User TechManagerReviewer { get; set; }

        public int? SalesManagerReviewerID { get; set; }
        [ForeignKey("SalesManagerReviewerID")]
        public virtual User SalesManagerReviewer { get; set; }

        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; } = new HashSet<ApprovalHistory>();
    }
}