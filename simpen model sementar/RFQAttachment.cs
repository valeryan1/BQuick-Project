using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQAttachment
    {
        [Key]
        public int RFQAttachmentID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        [Required]
        public string FileURL { get; set; }
        public DateTime UploadTimestamp { get; set; } = DateTime.UtcNow;

        public int? UploadedByUserID { get; set; } // FK ke User
        [ForeignKey("UploadedByUserID")]
        public virtual User UploadedByUser { get; set; }
    }
}