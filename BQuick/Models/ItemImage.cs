using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ItemImage
    {
        [Key]
        public int ImageID { get; set; }

        public int ItemID { get; set; }

        [Required]
        public byte[] ImageContent { get; set; }

        [Required, StringLength(255)]
        public string FileName { get; set; }

        public int? FileSize { get; set; }

        [StringLength(100)]
        public string FileType { get; set; }

        public bool IsMain { get; set; } = false;

        public int UploadedByID { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ItemID")]
        public virtual Item Item { get; set; }

        [ForeignKey("UploadedByID")]
        public virtual User UploadedBy { get; set; }
    }
}
