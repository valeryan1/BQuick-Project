using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Quotation
    {
        [Key]
        public int QuotationID { get; set; }

        [Required]
        [StringLength(50)]
        public string QuotationCode { get; set; } // Unik, diindeks

        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public string DeliveryInfo { get; set; }
        [StringLength(10)]
        public string Currency { get; set; } = "IDR";
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? ExchangeRate { get; set; }

        public int PaymentTermID { get; set; } // FK ke PaymentTerm
        [ForeignKey("PaymentTermID")]
        public virtual PaymentTerm PaymentTerm { get; set; }

        public int ShipmentTermID { get; set; } // FK ke ShipmentTerm
        [ForeignKey("ShipmentTermID")]
        public virtual ShipmentTerm ShipmentTerm { get; set; }

        public int PreparedByUserID { get; set; }
        [ForeignKey("PreparedByUserID")]
        public virtual User PreparedByUser { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalUnitCost_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPPN_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalEndorsement_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalFreight_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverallTotalCost_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalQuoteAmount_Customer { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverallMarginAmount_Internal { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal OverallMarginPercentage_Internal { get; set; }

        public string RemarkToCustomer { get; set; }
        public string InternalNotes { get; set; }
        public string FooterText { get; set; }

        public int QuotationStatusID { get; set; } // FK ke QuotationStatus
        [ForeignKey("QuotationStatusID")]
        public virtual QuotationStatus QuotationStatus { get; set; }

        public int? SplitParentQuotationID { get; set; }
        [ForeignKey("SplitParentQuotationID")]
        public virtual Quotation SplitParentQuotation { get; set; }
        public virtual ICollection<Quotation> SplitChildQuotations { get; set; }

        public int? SalesManagerApproverID { get; set; }
        [ForeignKey("SalesManagerApproverID")]
        public virtual User SalesManagerApprover { get; set; }
        public int? TechnicalManagerApproverID { get; set; }
        [ForeignKey("TechnicalManagerApproverID")]
        public virtual User TechnicalManagerApprover { get; set; }
        public int? DirectorApproverID { get; set; }
        [ForeignKey("DirectorApproverID")]
        public virtual User DirectorApprover { get; set; }

        public DateTime? SentToCustomerTimestamp { get; set; }
        public string SentToCustomerProofURL { get; set; }

        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<QuotationItem> Items { get; set; }
        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; }

        public Quotation()
        {
            Items = new HashSet<QuotationItem>();
            SplitChildQuotations = new HashSet<Quotation>();
            ApprovalHistories = new HashSet<ApprovalHistory>();
        }
    }
}