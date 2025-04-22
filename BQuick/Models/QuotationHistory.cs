using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class QuotationHistory
    {
        [Key]
        public int HistoryID { get; set; }

        public int QuotationID { get; set; }

        [Required, StringLength(50)]
        public string Action { get; set; }

        [Required]
        public string ChangeDetails { get; set; }

        [StringLength(50)]
        public string PreviousStatus { get; set; }

        [StringLength(50)]
        public string NewStatus { get; set; }

        public int ChangedByID { get; set; }

        public DateTime ChangedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("QuotationID")]
        public virtual Quotation Quotation { get; set; }

        [ForeignKey("ChangedByID")]
        public virtual User ChangedBy { get; set; }
    }
}
