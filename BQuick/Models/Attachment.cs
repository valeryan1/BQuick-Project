using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttachmentID { get; set; }

        [Required]
        public int RelatedID { get; set; }

        [Required]
        [StringLength(50)]
        public string RelatedType { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string FileType { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UploadedAt { get; set; }

        [ForeignKey("UploadedBy")]
        public int UploadedBy { get; set; }
        public virtual User User { get; set; }
    }
}
