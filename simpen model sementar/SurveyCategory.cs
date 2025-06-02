using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyCategory // Kompetensi
    {
        [Key]
        public int SurveyCategoryID { get; set; }
        [Required]
        [StringLength(150)]
        public string CategoryName { get; set; } // Security Access, Network Security
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
        public virtual ICollection<TechnicalCompetency> TechnicalCompetencies { get; set; }

        public SurveyCategory()
        {
            SurveyRequests = new HashSet<SurveyRequest>();
            TechnicalCompetencies = new HashSet<TechnicalCompetency>();
        }
    }
}