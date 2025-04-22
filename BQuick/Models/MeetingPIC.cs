using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingPIC
    {
        [Key]
        public int MeetingPICID { get; set; }

        public int MeetingID { get; set; }

        public int UserID { get; set; }

        [StringLength(100)]
        public string Role { get; set; }

        public bool IsRequired { get; set; } = true;

        [StringLength(50)]
        public string AttendanceStatus { get; set; }

        public DateTime? ResponseDate { get; set; }

        // Navigation properties
        [ForeignKey("MeetingID")]
        public virtual Meeting Meeting { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
