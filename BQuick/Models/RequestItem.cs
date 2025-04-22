using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RequestItem
    {
        public RequestItem()
        {
            RequestItemAttachments = new HashSet<RequestItemAttachment>();
            RequestItemResponses = new HashSet<RequestItemResponse>();
        }

        [Key]
        public int RequestItemID { get; set; }

        public int RFQID { get; set; }

        [Required, StringLength(255)]
        public string RequestTitle { get; set; }

        [Required]
        public string RequestDescription { get; set; }

        [Required, StringLength(50)]
        public string RequestType { get; set; }

        [Required, StringLength(50)]
        public string Priority { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; }

        public int RequestedByID { get; set; }

        public int AssignedToID { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("RequestedByID")]
        public virtual User RequestedBy { get; set; }

        [ForeignKey("AssignedToID")]
        public virtual User AssignedTo { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<RequestItemAttachment> RequestItemAttachments { get; set; }
        public virtual ICollection<RequestItemResponse> RequestItemResponses { get; set; }
    }
}
