using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SurveyID { get; set; }

        [ForeignKey("RFQ")]
        public int RFQID { get; set; }
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(20)]
        public string SurveyCode { get; set; }

        [Required]
        [StringLength(100)]
        public string SurveyName { get; set; }

        [Required]
        [StringLength(50)]
        public string SurveyType { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ScheduledDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CompletedDate { get; set; }

        [ForeignKey("AssignedUser")]
        public int AssignedTo { get; set; }
        public virtual User AssignedUser { get; set; }

        public ICollection<SurveyForm> SurveyForms { get; set; }
    }
}
