using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class QuotationItem
    {
        [Key]
        public int QuotationItemID { get; set; }

        public int QuotationID { get; set; }

        public int? ItemID { get; set; }

        [Required, StringLength(255)]
        public string ItemName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [StringLength(50)]
        public string UoM { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal DiscountPercentage { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,2)")]
        public decimal TaxPercentage { get; set; } = 0;

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } = 0;

        // Navigation properties
        [ForeignKey("QuotationID")]
        public virtual Quotation Quotation { get; set; }

        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }
    }
}
