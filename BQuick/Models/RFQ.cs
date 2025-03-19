using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class RFQ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RFQID { get; set; }

        [Required]
        [StringLength(20)]
        public string RFQCode { get; set; }

        [Required]
        [StringLength(100)]
        public string RFQName { get; set; }

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalBudget { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedByUser")]
        public int CreatedBy { get; set; }
        public virtual User CreatedByUser { get; set; }

        [ForeignKey("AssignedToUser")]
        public int AssignedTo { get; set; }
        public virtual User AssignedToUser { get; set; }

        public ICollection<RFQItem> RFQItems { get; set; }

        public ICollection<RFQNote> RFQNotes { get; set; }

        public ICollection<Survey> Surveys { get; set; }

        public ICollection<Meeting> Meetings { get; set; }

        public ICollection<Quotation> Quotations { get; set; }
    }
}
