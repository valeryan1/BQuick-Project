using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class UserDepartment
    {
        [Key]
        public int UserDepartmentID { get; set; }

        public int UserID { get; set; }

        public int DepartmentID { get; set; }

        public bool IsPrimary { get; set; } = false;

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }
    }
}
