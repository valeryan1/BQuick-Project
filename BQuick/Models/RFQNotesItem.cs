using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQNotesItem
    {
        [Key]
        public int NotesItemID { get; set; }

        public int RFQID { get; set; }

        [StringLength(255)]
        public string ItemName { get; set; }

        [StringLength(500)]
        public string ItemDescription { get; set; }

        public int Quantity { get; set; } = 1;

        [StringLength(50)]
        public string UoM { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Budget { get; set; }

        public int? Leadtime { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
