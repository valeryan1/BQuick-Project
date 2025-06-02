using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingStatus // Tabel Lookup
    {
        [Key]
        public int MeetingStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Not Yet, Waiting PIC Approval, On Progress, Completed
        public virtual ICollection<MeetingRequest> MeetingRequests { get; set; } = new HashSet<MeetingRequest>();
    }
}