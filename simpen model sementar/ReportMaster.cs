using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ReportMaster
    {
        [Key]
        public int ReportMasterID { get; set; }
        [Required]
        [StringLength(150)]
        public string ReportName { get; set; } // MLA, BoQ, MoM
        public string ReportTemplateDefinition { get; set; } // Path atau definisi template
        public bool IsActive { get; set; } = true;
        public virtual ICollection<SurveyReportInstance> SurveyReportInstances { get; set; }
        public virtual ICollection<MeetingReportInstance> MeetingReportInstances { get; set; }

        public ReportMaster()
        {
            SurveyReportInstances = new HashSet<SurveyReportInstance>();
            MeetingReportInstances = new HashSet<MeetingReportInstance>();
        }
    }
}