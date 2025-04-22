using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Report
    {
        public Report()
        {
            ReportAttachments = new HashSet<ReportAttachment>();
        }

        [Key]
        public int ReportID { get; set; }

        [StringLength(50)]
        public string ReportCode { get; set; }

        [Required, StringLength(255)]
        public string ReportTitle { get; set; }

        [Required, StringLength(50)]
        public string ReportType { get; set; }

        public int? RFQID { get; set; }

        public int? SurveyID { get; set; }

        [Required]
        public string ReportContent { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("SurveyID")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<ReportAttachment> ReportAttachments { get; set; }
    }
}
