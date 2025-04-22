using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class AuditLog
    {
        [Key]
        public int LogID { get; set; }

        public int UserID { get; set; }

        [Required, StringLength(50)]
        public string Action { get; set; }

        [Required, StringLength(50)]
        public string EntityType { get; set; }

        public int? EntityID { get; set; }

        [Required]
        public string Details { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(255)]
        public string UserAgent { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}
