using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class VendorItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorItemID { get; set; }

        [ForeignKey("Vendor")]
        public int VendorID { get; set; }
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public virtual Item Item { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }

        public int LeadTime { get; set; }

        public int WarrantyPeriod { get; set; }

        [StringLength(10)]
        public string WarrantyUnit { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidTo { get; set; }
    }
}
