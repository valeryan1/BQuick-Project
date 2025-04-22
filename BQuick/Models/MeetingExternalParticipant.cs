using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingExternalParticipant
    {
        [Key]
        public int ExternalParticipantID { get; set; }

        public int MeetingID { get; set; }

        public int? ContactID { get; set; }

        [StringLength(100)]
        public string ParticipantName { get; set; }

        [StringLength(100), EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(50)]
        public string AttendanceStatus { get; set; }

        // Navigation properties
        [ForeignKey("MeetingID")]
        public virtual Meeting Meeting { get; set; }

        [ForeignKey("ContactID")]
        public virtual CustomerContact Contact { get; set; }
    }
}
