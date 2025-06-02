using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public int RecipientUserID { get; set; }
        [ForeignKey("RecipientUserID")]
        public virtual User RecipientUser { get; set; }
        [Required]
        public string Message { get; set; }
        [StringLength(100)]
        public string NotificationType { get; set; } // NewTask, ApprovalRequest, Information
        [StringLength(100)]
        public string RelatedEntityType { get; set; } // RFQ, Quotation, SurveyRequest
        public int? RelatedEntityID { get; set; }
        public string NavigationURL { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;
    }
}