using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQOpportunity // Tabel Lookup
    {
        [Key]
        public int RFQOpportunityID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // General, Bundle Installation, Professional Service
        public virtual ICollection<RFQ> RFQs { get; set; } = new HashSet<RFQ>();
    }
}