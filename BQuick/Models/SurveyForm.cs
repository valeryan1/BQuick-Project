using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class SurveyForm
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FormID { get; set; }

        [ForeignKey("Survey")]
        public int SurveyID { get; set; }
        public virtual Survey Survey { get; set; }

        [Required]
        [StringLength(50)]
        public string FormType { get; set; }

        public string FormData { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }
    }
}
