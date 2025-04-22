using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class CustomerContact
    {
        public CustomerContact()
        {
            RFQs = new HashSet<RFQ>();
        }

        [Key]
        public int ContactID { get; set; }

        public int CompanyID { get; set; }

        [Required, StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(100)]
        public string Department { get; set; }

        [StringLength(50)]
        public string ContactType { get; set; }

        [StringLength(100), EmailAddress]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string MobileNumber { get; set; }

        public bool IsDecisionMaker { get; set; } = false;

        public bool IsEndUser { get; set; } = false;

        public bool IsPersonal { get; set; } = false;

        public byte[] ProfilePicture { get; set; }

        [StringLength(255)]
        public string ProfilePictureFileName { get; set; }

        [StringLength(100)]
        public string ProfilePictureFileType { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<RFQ> RFQs { get; set; }
    }
}
