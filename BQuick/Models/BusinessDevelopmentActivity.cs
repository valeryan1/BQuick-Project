using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class BusinessDevelopmentActivity
    {
        [Key]
        public int ActivityID { get; set; }

        public int? RFQID { get; set; }

        public int CompanyID { get; set; }

        public int? ContactID { get; set; }

        [Required, StringLength(255)]
        public string ActivityTitle { get; set; }

        [Required, StringLength(50)]
        public string ActivityType { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime ActivityDate { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(255)]
        public string Outcome { get; set; }

        [StringLength(255)]
        public string NextSteps { get; set; }

        public DateTime? FollowUpDate { get; set; }

        public int PerformedByID { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("ContactID")]
        public virtual CustomerContact Contact { get; set; }

        [ForeignKey("PerformedByID")]
        public virtual User PerformedBy { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
