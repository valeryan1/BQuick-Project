using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } // misalnya "Admin Sales", "Sales Manager"

        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}