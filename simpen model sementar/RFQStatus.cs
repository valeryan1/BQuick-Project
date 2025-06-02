using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQStatus // Tabel Lookup
    {
        [Key]
        public int RFQStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Waiting Assign, Open, Waiting Purchasing, etc.
        public virtual ICollection<RFQ> RFQs { get; set; } = new HashSet<RFQ>();
    }
}