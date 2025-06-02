using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class QuotationItem
    {
        [Key]
        public int QuotationItemID { get; set; }
        public int QuotationID { get; set; }
        [ForeignKey("QuotationID")]
        public virtual Quotation Quotation { get; set; }

        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        public int? RFQ_ItemID { get; set; }
        [ForeignKey("RFQ_ItemID")]
        public virtual RFQ_Item RFQ_Item { get; set; }

        public string DescriptionOverride { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost_Internal { get; set; }

        [Column(TypeName = "decimal(5, 4)")]
        public decimal? PPN_Percentage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PPN_FixedAmount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Endorsement_Amount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Freight_AmountPerUnit { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCostPerUnit_Internal { get; set; } // Kalkulasi
        [Column(TypeName = "decimal(18, 2)")]
        public decimal QuotePricePerUnit_Customer { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalQuotePrice_Customer { get; set; } // Kalkulasi
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MarginAmount_Internal { get; set; } // Kalkulasi
        [Column(TypeName = "decimal(18, 4)")]
        public decimal MarginPercentage_Internal { get; set; } // Kalkulasi

        [StringLength(100)]
        public string SalesWarranty { get; set; }
        public bool DisplayWithDetailInternal { get; set; }
        public int DisplaySequence { get; set; }
    }
}