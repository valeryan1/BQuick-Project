using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyRequest
    {
        [Key]
        public int SurveyRequestID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(50)]
        public string SurveyCode { get; set; } // Unik, diindeks
        [StringLength(255)]
        public string SurveyName { get; set; }

        public int SurveyCategoryID { get; set; }
        [ForeignKey("SurveyCategoryID")]
        public virtual SurveyCategory SurveyCategory { get; set; }

        [StringLength(150)]
        public string CustomerPICName { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public string LocationDetails { get; set; }
        public string SalesNotesInternal { get; set; }

        public int SurveyStatusID { get; set; } // FK ke SurveyStatus
        [ForeignKey("SurveyStatusID")]
        public virtual SurveyStatus SurveyStatus { get; set; }

        public int CreatedByUserID { get; set; }
        [ForeignKey("CreatedByUserID")]
        public virtual User CreatedByUser { get; set; }

        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<SurveyPIC> AssignedPICs { get; set; }
        public virtual ICollection<SurveyInstance> SurveyInstances { get; set; }

        public SurveyRequest()
        {
            AssignedPICs = new HashSet<SurveyPIC>();
            SurveyInstances = new HashSet<SurveyInstance>();
        }
    }
}