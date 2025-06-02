using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class VendorBank
    {
        [Key]
        public int VendorBankID { get; set; }
        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        public virtual Vendor Vendor { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; }
        [StringLength(100)]
        public string BranchName { get; set; }
        [Required]
        [StringLength(150)]
        public string AccountHolderName { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }
        [StringLength(20)]
        public string SwiftCode { get; set; }
    }
}