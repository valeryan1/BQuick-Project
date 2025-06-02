using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class PurchasingStatus // Tabel Lookup
    {
        [Key]
        public int PurchasingStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Open, On Progress, Completed, Escalation
        public virtual ICollection<PurchasingRequest> PurchasingRequests { get; set; } = new HashSet<PurchasingRequest>();
    }
}