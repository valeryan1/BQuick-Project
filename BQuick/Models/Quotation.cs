using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class Quotation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuotationID { get; set; }

        [Required]
        [StringLength(20)]
        public string QuotationCode { get; set; }

        [ForeignKey("RFQ")]
        public int RFQID { get; set; }
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ValidUntil { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }

        public ICollection<QuotationItem> QuotationItems { get; set; }

        public ICollection<QuotationApproval> Approvals { get; set; }
    }
}
