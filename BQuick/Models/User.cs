using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BQuick.Models
{
    public class User
    {
        public User()
        {
            UserDepartments = new HashSet<UserDepartment>();
            Subordinates = new HashSet<User>();
            CreatedCompanies = new HashSet<Company>();
            ModifiedCompanies = new HashSet<Company>();
            AssignedRFQsAsAdminSales = new HashSet<RFQ>();
            AssignedRFQsAsSales = new HashSet<RFQ>();
            AssignedRFQsAsBusinessDevelopment = new HashSet<RFQ>();
            AssignedRFQsAsPreSalesSupport = new HashSet<RFQ>();
            AssignedRFQsAsPMO = new HashSet<RFQ>();
        }

        [Key]
        public int UserID { get; set; }

        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(255)]
        public string Password { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }

        [Required, StringLength(100), EmailAddress]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Role { get; set; }

        [StringLength(100)]
        public string Specialization { get; set; }

        [Required, StringLength(100)]
        public string Department { get; set; }

        [Required, StringLength(100)]
        public string Division { get; set; }

        public int? ReportsToID { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastLoginDate { get; set; }

        public int? ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ReportsToID")]
        public virtual User Manager { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<UserDepartment> UserDepartments { get; set; }
        public virtual ICollection<User> Subordinates { get; set; }
        public virtual ICollection<Company> CreatedCompanies { get; set; }
        public virtual ICollection<Company> ModifiedCompanies { get; set; }
        public virtual ICollection<RFQ> AssignedRFQsAsAdminSales { get; set; }
        public virtual ICollection<RFQ> AssignedRFQsAsSales { get; set; }
        public virtual ICollection<RFQ> AssignedRFQsAsBusinessDevelopment { get; set; }
        public virtual ICollection<RFQ> AssignedRFQsAsPreSalesSupport { get; set; }
        public virtual ICollection<RFQ> AssignedRFQsAsPMO { get; set; }
    }
}
