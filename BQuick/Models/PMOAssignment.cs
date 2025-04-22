using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class PMOAssignment
    {
        [Key]
        public int AssignmentID { get; set; }

        public int RFQID { get; set; }

        public int PMOID { get; set; }

        [Required, StringLength(50)]
        public string Role { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int AssignedByID { get; set; }

        public DateTime AssignedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("PMOID")]
        public virtual User PMO { get; set; }

        [ForeignKey("AssignedByID")]
        public virtual User AssignedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
