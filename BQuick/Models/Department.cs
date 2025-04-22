using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Department
    {
        public Department()
        {
            UserDepartments = new HashSet<UserDepartment>();
        }

        [Key]
        public int DepartmentID { get; set; }

        [Required, StringLength(100)]
        public string DepartmentName { get; set; }

        [Required, StringLength(100)]
        public string DivisionName { get; set; }

        public int? DepartmentHeadID { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("DepartmentHeadID")]
        public virtual User DepartmentHead { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
    }
}
