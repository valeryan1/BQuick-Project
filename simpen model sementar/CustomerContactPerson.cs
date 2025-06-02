using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class CustomerContactPerson
    {
        [Key]
        public int ContactPersonID { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public bool IsPrimary { get; set; } = false;
    }
}