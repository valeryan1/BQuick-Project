using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ApprovalHistory
    {
        [Key]
        public int ApprovalHistoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string EntityType { get; set; } // "Quotation", "SurveyReportInstance", "MeetingReportInstance"

        [Required]
        public int EntityID { get; set; } // FK ke entitas terkait

        public int ApproverUserID { get; set; }
        [ForeignKey("ApproverUserID")]
        public virtual User ApproverUser { get; set; }

        [StringLength(100)]
        public string ApproverRoleAtTime { get; set; }

        public int ApprovalDecisionStatusID { get; set; } // FK ke ApprovalDecisionStatus
        [ForeignKey("ApprovalDecisionStatusID")]
        public virtual ApprovalDecisionStatus ApprovalDecisionStatus { get; set; }

        public string Remarks { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int StepOrder { get; set; } // Urutan persetujuan jika relevan
    }
}