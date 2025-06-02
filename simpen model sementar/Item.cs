using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(50)]
        public string ItemCode { get; set; } // Unik, diindeks

        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }

        public string ItemDescription { get; set; }
        public string ItemImageURL { get; set; }

        public int ItemCategoryID { get; set; }
        [ForeignKey("ItemCategoryID")]
        public virtual ItemCategory ItemCategory { get; set; }

        public int? ItemTypeID { get; set; }
        [ForeignKey("ItemTypeID")]
        public virtual ItemType ItemType { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }
        public string SpecificationDetails { get; set; }

        public decimal? DimensionL { get; set; }
        public decimal? DimensionW { get; set; }
        public decimal? DimensionH { get; set; }
        [StringLength(10)]
        public string DimensionUnit { get; set; } = "cm";
        public decimal? Weight { get; set; }
        [StringLength(10)]
        public string WeightUnit { get; set; } = "kg";

        [StringLength(50)]
        public string ShipmentMethod { get; set; }

        public bool IsTKDN { get; set; } = false;
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? TKDNPercentage { get; set; }
        [StringLength(100)]
        public string TKDNCertificateNumber { get; set; } = string.Empty;
        public string TKDNCertificateAttachmentURL { get; set; } = string.Empty;

        [StringLength(50)]
        public string SoftwareVersion { get; set; }
        [StringLength(100)]
        public string LicenseType { get; set; }
        [StringLength(50)]
        public string ItemServiceType { get; set; } // "External" / "Internal"

        public int StockQuantity { get; set; } = 0;
        public bool IsEOS { get; set; } = false; // End of Sale
        public bool IsEOL { get; set; } = false; // End of Life

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ItemBundle> ParentBundleItems { get; set; }
        public virtual ICollection<ItemBundle> ChildBundleItems { get; set; }
        public virtual ICollection<RFQ_Item> RFQItems { get; set; }
        public virtual ICollection<ItemVendorPricing> VendorPricings { get; set; }
        public virtual ICollection<QuotationItem> QuotationItems { get; set; }

        public Item()
        {
            ParentBundleItems = new HashSet<ItemBundle>();
            ChildBundleItems = new HashSet<ItemBundle>();
            RFQItems = new HashSet<RFQ_Item>();
            VendorPricings = new HashSet<ItemVendorPricing>();
            QuotationItems = new HashSet<QuotationItem>();
        }
    }
}