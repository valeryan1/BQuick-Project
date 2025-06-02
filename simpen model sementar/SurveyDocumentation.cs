using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class SurveyDocumentation
    {
        [Key]
        public int SurveyDocumentationID { get; set; }
        public int SurveyInstanceID { get; set; }
        [ForeignKey("SurveyInstanceID")]
        public virtual SurveyInstance SurveyInstance { get; set; }
        [Required, StringLength(255)]
        public string FileName { get; set; }
        [Required]
        public string FileURL { get; set; }
        public int UploadedByUserID { get; set; }
        [ForeignKey("UploadedByUserID")]
        public virtual User UploadedByUser { get; set; }
        public DateTime UploadTimestamp { get; set; } = DateTime.UtcNow;
    }
}