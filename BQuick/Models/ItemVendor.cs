using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ItemVendor
    {
        [Key]
        public int ItemVendorID { get; set; }

        public int ItemID { get; set; }

        public int VendorID { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        [StringLength(10)]
        public string Currency { get; set; } = "IDR";

        public int? LeadTime { get; set; }

        public int MinimumOrderQuantity { get; set; } = 1;

        public int? WarrantyPeriod { get; set; }

        [StringLength(20)]
        public string WarrantyUnit { get; set; }

        public DateTime? PriceStartDate { get; set; }

        public DateTime? PriceEndDate { get; set; }

        public bool IsPreferred { get; set; } = false;

        [StringLength(500)]
        public string Notes { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
