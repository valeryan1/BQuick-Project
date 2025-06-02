using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class PurchasingRequest
    {
        [Key]
        public int PurchasingRequestID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        public int? ItemID_IfExists { get; set; }
        [ForeignKey("ItemID_IfExists")]
        public virtual Item ItemIfExists { get; set; }

        [StringLength(255)]
        public string RequestedItemName { get; set; }
        public string RequestedItemDescription { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }
        [StringLength(100)]
        public string ReasonForRequest { get; set; } // Not yet in Database, Leadtime not suitable, dll.
        public string SalesNotes { get; set; }
        public string SalesAttachmentURL { get; set; }

        public int? AssignedToPurchasingUserID { get; set; }
        [ForeignKey("AssignedToPurchasingUserID")]
        public virtual User AssignedToPurchasingUser { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }

        public int PurchasingStatusID { get; set; } // FK ke PurchasingStatus
        [ForeignKey("PurchasingStatusID")]
        public virtual PurchasingStatus PurchasingStatus { get; set; }

        public int RequestedByUserID { get; set; }
        [ForeignKey("RequestedByUserID")]
        public virtual User RequestedByUser { get; set; }

        public virtual ICollection<RFQ_Item> ResultingRFQItems { get; set; } = new HashSet<RFQ_Item>();
    }
}