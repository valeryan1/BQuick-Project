using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQItemAddOn
    {
        [Key]
        public int AddOnID { get; set; }

        public int RFQItemID { get; set; }

        [StringLength(255)]
        public string AddOnName { get; set; }

        [StringLength(500)]
        public string AddOnDescription { get; set; }

        public int AddOnQty { get; set; } = 1;

        [StringLength(50)]
        public string AddOnUoM { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AddOnUnitPrice { get; set; }

        // Navigation properties
        [ForeignKey("RFQItemID")]
        public virtual RFQItem RFQItem { get; set; }
    }
}
