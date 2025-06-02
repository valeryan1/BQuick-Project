using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyPIC
    {
        [Key]
        public int SurveyPIC_ID { get; set; }
        public int SurveyRequestID { get; set; }
        [ForeignKey("SurveyRequestID")]
        public virtual SurveyRequest SurveyRequest { get; set; }

        public int TechnicalUserID { get; set; }
        [ForeignKey("TechnicalUserID")]
        public virtual User TechnicalUser { get; set; }

        public int PICApprovalStatusID { get; set; } // FK ke PICApprovalStatus
        [ForeignKey("PICApprovalStatusID")]
        public virtual PICApprovalStatus PICApprovalStatus { get; set; }
    }
}