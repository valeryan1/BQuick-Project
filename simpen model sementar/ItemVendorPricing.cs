using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ItemVendorPricing
    {
        [Key]
        public int ItemVendorPricingID { get; set; }
        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [StringLength(10)]
        public string Currency { get; set; }

        public int? LeadTimeValue { get; set; }
        [StringLength(20)]
        public string LeadTimeUnit { get; set; } // Days, Weeks

        public int? WarrantyPeriod { get; set; }
        [StringLength(20)]
        public string WarrantyUnit { get; set; } // "Months", "Years"
        public DateTime PriceValidityStartDate { get; set; }
        public DateTime PriceValidityEndDate { get; set; }
        public int? MinOrderQuantity { get; set; }
        public string Notes { get; set; }
        public int? StockAvailableAtVendor { get; set; }

        public DateTime LastUpdatedTimestamp { get; set; } = DateTime.UtcNow;
    }
}