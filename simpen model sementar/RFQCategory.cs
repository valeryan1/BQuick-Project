using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQCategory // Tabel Lookup
    {
        [Key]
        public int RFQCategoryID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Project, Middle Project, Non-Project
        public virtual ICollection<RFQ> RFQs { get; set; } = new HashSet<RFQ>();
    }
}