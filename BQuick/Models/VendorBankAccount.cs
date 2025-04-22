using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class VendorBankAccount
    {
        [Key]
        public int BankAccountID { get; set; }

        public int VendorID { get; set; }

        [Required, StringLength(100)]
        public string BankName { get; set; }

        [StringLength(100)]
        public string Branch { get; set; }

        [Required, StringLength(100)]
        public string AccountHolderName { get; set; }

        [Required, StringLength(50)]
        public string AccountNumber { get; set; }

        [StringLength(50)]
        public string SwiftCode { get; set; }

        [StringLength(10)]
        public string Currency { get; set; } = "IDR";

        public bool IsDefault { get; set; } = false;

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
