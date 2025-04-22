using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class InventoryMovement
    {
        [Key]
        public int MovementID { get; set; }

        public int ItemID { get; set; }

        [Required, StringLength(50)]
        public string MovementType { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int PreviousStock { get; set; }

        public int CurrentStock { get; set; }

        [StringLength(255)]
        public string Reference { get; set; }

        [StringLength(50)]
        public string ReferenceType { get; set; }

        public int? ReferenceID { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        public int PerformedByID { get; set; }

        public DateTime MovementDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        [ForeignKey("PerformedByID")]
        public virtual User PerformedBy { get; set; }
    }
}
