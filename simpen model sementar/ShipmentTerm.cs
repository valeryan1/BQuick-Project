using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ShipmentTerm // Tabel Lookup
    {
        [Key]
        public int ShipmentTermID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // DDP PEB, FOB Batam, etc.
        public bool IsActive { get; set; } = true;
        public virtual ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }
}