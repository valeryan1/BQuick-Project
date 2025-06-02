using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class ApprovalDecisionStatus // Tabel Lookup
    {
        [Key]
        public int ApprovalDecisionStatusID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } // Approved, Rejected, Requested Revision, Pending
        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; } = new HashSet<ApprovalHistory>();
    }
}