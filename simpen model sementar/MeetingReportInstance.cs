using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingReportInstance // MoM
    {
        [Key]
        public int MeetingReportInstanceID { get; set; }
        public int MeetingRequestID { get; set; }
        [ForeignKey("MeetingRequestID")]
        public virtual MeetingRequest MeetingRequest { get; set; }
        public int ReportMasterID { get; set; } // FK (MoM Type dari ReportMaster)
        [ForeignKey("ReportMasterID")]
        public virtual ReportMaster ReportMaster { get; set; }
        public string ReportContent { get; set; } // Path ke file MoM atau kontennya
        public int GeneratedByUserID { get; set; }
        [ForeignKey("GeneratedByUserID")]
        public virtual User GeneratedByUser { get; set; }
        public DateTime GeneratedTimestamp { get; set; } = DateTime.UtcNow;

        public int ReportStatusID { get; set; } // FK ke ReportStatus
        [ForeignKey("ReportStatusID")]
        public virtual ReportStatus ReportStatus { get; set; } // Mis: Saved, Completed

        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; } = new HashSet<ApprovalHistory>();
    }
}