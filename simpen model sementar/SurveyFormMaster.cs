using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyFormMaster
    {
        [Key]
        public int SurveyFormID { get; set; }
        [Required]
        [StringLength(150)]
        public string FormName { get; set; } // Access Control Form
        public string FormTemplateDefinition { get; set; } // JSON/XML struktur atau path
        public bool IsActive { get; set; } = true;
        public virtual ICollection<SurveyInstance> SurveyInstances { get; set; }
        public SurveyFormMaster()
        {
            SurveyInstances = new HashSet<SurveyInstance>();
        }
    }
}