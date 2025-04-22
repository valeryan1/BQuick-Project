using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Survey
    {
        public Survey()
        {
            SurveyPICs = new HashSet<SurveyPIC>();
            SurveyForms = new HashSet<SurveyForm>();
            SurveyResults = new HashSet<SurveyResult>();
            SurveyAttachments = new HashSet<SurveyAttachment>();
        }

        [Key]
        public int SurveyID { get; set; }

        public int RFQID { get; set; }

        [Required, StringLength(100)]
        public string SurveyCode { get; set; }

        [Required, StringLength(255)]
        public string SurveyTitle { get; set; }

        [Required]
        public string SurveyDescription { get; set; }

        [Required, StringLength(50)]
        public string SurveyType { get; set; }

        [Required, StringLength(50)]
        public string Status { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        public DateTime SurveyDate { get; set; }

        public DateTime? CompletionDate { get; set; }

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

        public virtual ICollection<SurveyPIC> SurveyPICs { get; set; }
        public virtual ICollection<SurveyForm> SurveyForms { get; set; }
        public virtual ICollection<SurveyResult> SurveyResults { get; set; }
        public virtual ICollection<SurveyAttachment> SurveyAttachments { get; set; }
    }
}
