using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Quotation
    {
        public Quotation()
        {
            QuotationItems = new HashSet<QuotationItem>();
            QuotationAttachments = new HashSet<QuotationAttachment>();
            QuotationHistories = new HashSet<QuotationHistory>();
        }

        [Key]
        public int QuotationID { get; set; }

        [Required, StringLength(50)]
        public string QuotationNumber { get; set; }

        public int RFQID { get; set; }

        [Required, StringLength(255)]
        public string QuotationTitle { get; set; }

        public int Version { get; set; } = 1;

        public DateTime QuotationDate { get; set; } = DateTime.Now;

        public DateTime ValidUntil { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(50)]
        public string PaymentTerm { get; set; }

        [StringLength(50)]
        public string DeliveryTerm { get; set; }

        public int? DeliveryTime { get; set; }

        [StringLength(20)]
        public string DeliveryTimeUnit { get; set; }

        [StringLength(50)]
        public string Warranty { get; set; }

        [StringLength(10)]
        public string Currency { get; set; } = "IDR";

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxPercentage { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal GrandTotal { get; set; } = 0;

        public string Notes { get; set; }

        public string TermsAndConditions { get; set; }

        public int PreparedByID { get; set; }

        public int? ApprovedByID { get; set; }

        public DateTime? ApprovalDate { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("PreparedByID")]
        public virtual User PreparedBy { get; set; }

        [ForeignKey("ApprovedByID")]
        public virtual User ApprovedBy { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<QuotationItem> QuotationItems { get; set; }
        public virtual ICollection<QuotationAttachment> QuotationAttachments { get; set; }
        public virtual ICollection<QuotationHistory> QuotationHistories { get; set; }
    }
}
