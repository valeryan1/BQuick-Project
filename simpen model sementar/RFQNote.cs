using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQNote
    {
        [Key]
        public int RFQNoteID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [StringLength(255)]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BudgetTarget { get; set; }
        [StringLength(100)]
        public string LeadTimeTarget { get; set; }
    }
}