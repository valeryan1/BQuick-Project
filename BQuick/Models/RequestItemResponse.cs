using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RequestItemResponse
    {
        [Key]
        public int ResponseID { get; set; }

        public int RequestItemID { get; set; }

        [Required]
        public string ResponseText { get; set; }

        public int RespondedByID { get; set; }

        public DateTime ResponseDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("RequestItemID")]
        public virtual RequestItem RequestItem { get; set; }

        [ForeignKey("RespondedByID")]
        public virtual User RespondedBy { get; set; }
    }
}
