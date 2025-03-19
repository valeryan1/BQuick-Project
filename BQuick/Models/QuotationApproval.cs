using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class QuotationApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApprovalID { get; set; }

        [ForeignKey("Quotation")]
        public int QuotationID { get; set; }
        public virtual Quotation Quotation { get; set; }

        [ForeignKey("Approver")]
        public int ApproverID { get; set; }
        public virtual User Approver { get; set; }

        [Required]
        public int ApprovalLevel { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? ApprovedAt { get; set; }

        public string Comments { get; set; }
    }
}
