using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }

        [Required]
        [StringLength(20)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(100)]
        public string ItemName { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string SubCategory { get; set; }

        [StringLength(20)]
        public string UnitOfMeasure { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }

        public ICollection<RFQItem> RFQItems { get; set; }

        public ICollection<QuotationItem> QuotationItems { get; set; }

        public ICollection<VendorItem> VendorItems { get; set; }
    }
}
