using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingPIC
    {
        [Key]
        public int MeetingPIC_ID { get; set; }
        public int MeetingRequestID { get; set; }
        [ForeignKey("MeetingRequestID")]
        public virtual MeetingRequest MeetingRequest { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        public int PICApprovalStatusID { get; set; } // FK ke PICApprovalStatus
        [ForeignKey("PICApprovalStatusID")]
        public virtual PICApprovalStatus PICApprovalStatus { get; set; }
    }
}