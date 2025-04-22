using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class VendorAttachment
    {
        [Key]
        public int AttachmentID { get; set; }

        public int VendorID { get; set; }

        [Required, StringLength(255)]
        public string FileName { get; set; }

        [Required]
        public byte[] FileContent { get; set; }

        public int? FileSize { get; set; }

        [StringLength(100)]
        public string FileType { get; set; }

        [StringLength(100)]
        public string DocumentType { get; set; }

        public DateTime? ExpiryDate { get; set; }

        public int UploadedByID { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("UploadedByID")]
        public virtual User UploadedBy { get; set; }
    }
}
