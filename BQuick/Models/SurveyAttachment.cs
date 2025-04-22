using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyAttachment
    {
        [Key]
        public int AttachmentID { get; set; }

        public int SurveyID { get; set; }

        [Required, StringLength(255)]
        public string FileName { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        public int? FileSize { get; set; }

        [StringLength(100)]
        public string FileType { get; set; }

        [StringLength(100)]
        public string AttachmentType { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int UploadedByID { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("SurveyID")]
        public virtual Survey Survey { get; set; }

        [ForeignKey("UploadedByID")]
        public virtual User UploadedBy { get; set; }
    }
}
