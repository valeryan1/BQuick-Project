// File: BQuick/Models/ContactPersonCreateViewModel.cs
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class ContactPersonCreateViewModel
    {
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string? Position { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        public bool IsPrimary { get; set; }
    }
}
