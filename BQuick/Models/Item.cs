using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Item
    {
        public Item()
        {
            ItemImages = new HashSet<ItemImage>();
            ItemVendors = new HashSet<ItemVendor>();
            RFQItems = new HashSet<RFQItem>();
        }

        [Key]
        public int ItemID { get; set; }

        [Required, StringLength(50)]
        public string ItemCode { get; set; }

        [Required, StringLength(255)]
        public string ItemName { get; set; }

        public string Description { get; set; }

        [Required, StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string ItemType { get; set; }

        [StringLength(100)]
        public string Manufacturer { get; set; }

        [StringLength(100)]
        public string ModelNumber { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } = 0;

        [StringLength(10)]
        public string Currency { get; set; } = "IDR";

        public int? LeadTime { get; set; }

        public bool IsEOS { get; set; } = false;

        public bool IsEOL { get; set; } = false;

        public DateTime? EOSDate { get; set; }

        public DateTime? EOLDate { get; set; }

        public int StockQty { get; set; } = 0;

        public int MinimumStockLevel { get; set; } = 0;

        public bool IsTKDN { get; set; } = false;

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TKDNPercentage { get; set; }

        [StringLength(100)]
        public string CertificateNo { get; set; }

        [StringLength(50)]
        public string ShipmentMethod { get; set; }

        public int? WarrantyPeriod { get; set; }

        [StringLength(20)]
        public string WarrantyUnit { get; set; }

        public string TechnicalSpecification { get; set; }

        [StringLength(50)]
        public string UoM { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<ItemImage> ItemImages { get; set; }
        public virtual ICollection<ItemVendor> ItemVendors { get; set; }
        public virtual ICollection<RFQItem> RFQItems { get; set; }
    }
}
