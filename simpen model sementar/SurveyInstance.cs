using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyInstance
    {
        [Key]
        public int SurveyInstanceID { get; set; }
        public int SurveyRequestID { get; set; }
        [ForeignKey("SurveyRequestID")]
        public virtual SurveyRequest SurveyRequest { get; set; }

        public int SurveyFormID { get; set; }
        [ForeignKey("SurveyFormID")]
        public virtual SurveyFormMaster SurveyForm { get; set; }

        public DateTime? ActualSurveyStartTime { get; set; }
        public DateTime? ActualSurveyEndTime { get; set; }
        public string FilledFormData { get; set; } // JSON/XML

        public int SubmittedByUserID { get; set; }
        [ForeignKey("SubmittedByUserID")]
        public virtual User SubmittedByUser { get; set; }

        [StringLength(50)]
        public string SubmissionStatus { get; set; } // Saved, Sent (pertimbangkan FK ke lookup jika ada banyak status)
        public DateTime SubmissionTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<SurveyDocumentation> Documentations { get; set; }
        public virtual ICollection<SurveyReportInstance> Reports { get; set; }
        public SurveyInstance()
        {
            Documentations = new HashSet<SurveyDocumentation>();
            Reports = new HashSet<SurveyReportInstance>();
        }
    }
}