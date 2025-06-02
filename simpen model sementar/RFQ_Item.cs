using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQ_Item
    {
        [Key]
        public int RFQ_ItemID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TargetUnitPrice { get; set; }
        public string Notes { get; set; }
        public string Details { get; set; }
        [StringLength(100)]
        public string SalesWarranty { get; set; }

        public int? ChosenVendorID { get; set; }
        [ForeignKey("ChosenVendorID")]
        public virtual Vendor ChosenVendor { get; set; }

        public int? OriginatingPurchasingRequestID { get; set; }
        [ForeignKey("OriginatingPurchasingRequestID")]
        public virtual PurchasingRequest OriginatingPurchasingRequest { get; set; }
    }
}