using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingRequest
    {
        [Key]
        public int MeetingRequestID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }
        [Required]
        [StringLength(50)]
        public string MeetingCode { get; set; } // Unik, diindeks
        [StringLength(255)]
        public string MeetingName { get; set; }
        public int PrimaryPIC_UserID { get; set; }
        [ForeignKey("PrimaryPIC_UserID")]
        public virtual User PrimaryPIC_User { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public string LocationDetails { get; set; } // Offline / Online (link)
        public string NotesInternal { get; set; }

        public int MeetingStatusID { get; set; } // FK ke MeetingStatus
        [ForeignKey("MeetingStatusID")]
        public virtual MeetingStatus MeetingStatus { get; set; }

        public int CreatedByUserID { get; set; }
        [ForeignKey("CreatedByUserID")]
        public virtual User CreatedByUser { get; set; }
        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<MeetingPIC> AssignedPICs { get; set; }
        public virtual ICollection<MeetingReportInstance> Reports { get; set; }

        public MeetingRequest()
        {
            AssignedPICs = new HashSet<MeetingPIC>();
            Reports = new HashSet<MeetingReportInstance>();
        }
    }
}