using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MeetingMinute
    {
        [Key]
        public int MinuteID { get; set; }

        public int MeetingID { get; set; }

        [Required]
        public string MinuteContent { get; set; }

        [StringLength(255)]
        public string ActionItem { get; set; }

        public int? AssignedToID { get; set; }

        public DateTime? DueDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("MeetingID")]
        public virtual Meeting Meeting { get; set; }

        [ForeignKey("AssignedToID")]
        public virtual User AssignedTo { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
