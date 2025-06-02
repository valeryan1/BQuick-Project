using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class PaymentTerm // Tabel Lookup
    {
        [Key]
        public int PaymentTermID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // 30 days, Cash In Advance, etc.
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Customer> CustomersAsDefault { get; set; } = new HashSet<Customer>();
        public virtual ICollection<Vendor> VendorsAsDefault { get; set; } = new HashSet<Vendor>();
        public virtual ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }
}