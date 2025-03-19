using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorID { get; set; }

        [Required]
        [StringLength(20)]
        public string VendorCode { get; set; }

        [Required]
        [StringLength(100)]
        public string VendorName { get; set; }

        [StringLength(100)]
        public string ContactPerson { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }

        public ICollection<VendorItem> VendorItems { get; set; }

        public ICollection<VendorBankAccount> BankAccounts { get; set; }
    }
}
