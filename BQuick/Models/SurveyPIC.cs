using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyPIC
    {
        [Key]
        public int SurveyPICID { get; set; }

        public int SurveyID { get; set; }

        public int UserID { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        public bool IsLeader { get; set; } = false;

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("SurveyID")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }
    }
}
