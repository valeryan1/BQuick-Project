using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyResult
    {
        [Key]
        public int ResultID { get; set; }

        public int SurveyID { get; set; }

        [Required]
        public string ResultContent { get; set; }

        [StringLength(255)]
        public string Conclusion { get; set; }

        [StringLength(255)]
        public string Recommendation { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("SurveyID")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
