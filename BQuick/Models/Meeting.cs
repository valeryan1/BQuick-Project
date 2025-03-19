using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class Meeting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetingID { get; set; }

        [ForeignKey("RFQ")]
        public int RFQID { get; set; }
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(20)]
        public string MeetingCode { get; set; }

        [Required]
        [StringLength(100)]
        public string MeetingName { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        public DateTime? ScheduledDate { get; set; }

        [StringLength(100)]
        public string Location { get; set; }

        public string Notes { get; set; }

        public ICollection<MeetingParticipant> Participants { get; set; }
    }
}
