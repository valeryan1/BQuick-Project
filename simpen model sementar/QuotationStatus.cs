using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class QuotationStatus // Tabel Lookup
    {
        [Key]
        public int QuotationStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Draft, Waiting SM Approval, Approved by Director, Sent to Customer
        public virtual ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }
}