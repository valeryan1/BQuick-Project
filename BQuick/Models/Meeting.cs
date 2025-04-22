using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Meeting
    {
        public Meeting()
        {
            MeetingPICs = new HashSet<MeetingPIC>();
            MeetingExternalParticipants = new HashSet<MeetingExternalParticipant>();
            MeetingAttachments = new HashSet<MeetingAttachment>();
            MeetingMinutes = new HashSet<MeetingMinute>();
        }

        [Key]
        public int MeetingID { get; set; }

        [Required, StringLength(255)]
        public string MeetingTitle { get; set; }

        public int? RFQID { get; set; }

        [Required, StringLength(50)]
        public string MeetingType { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string MeetingRoom { get; set; }

        [StringLength(255)]
        public string VirtualMeetingLink { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public string Agenda { get; set; }

        public string Notes { get; set; }

        public int OrganizedByID { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [ForeignKey("OrganizedByID")]
        public virtual User OrganizedBy { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<MeetingPIC> MeetingPICs { get; set; }
        public virtual ICollection<MeetingExternalParticipant> MeetingExternalParticipants { get; set; }
        public virtual ICollection<MeetingAttachment> MeetingAttachments { get; set; }
        public virtual ICollection<MeetingMinute> MeetingMinutes { get; set; }
    }
}
