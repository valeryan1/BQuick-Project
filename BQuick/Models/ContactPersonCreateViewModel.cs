// File: BQuick/Models/ContactPersonCreateViewModel.cs
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Required for IFormFile

namespace BQuick.Models
{
    public class ContactPersonCreateViewModel
    {
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string? Title { get; set; } // This will be used for 'Title' (Mr, Mrs, Ms)

        [StringLength(100)]
        public string? JobPosition { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        public string? Mobile { get; set; }

        public string? Notes { get; set; }

        public IFormFile? ProfilePicture { get; set; }

        public bool IsPrimary { get; set; }
    }
}
