using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        public DateTime? LastLogin { get; set; }

        public ICollection<RFQ> CreatedRFQs { get; set; }
        public ICollection<RFQ> AssignedRFQs { get; set; }

        public ICollection<Survey> AssignedSurveys { get; set; }

        public ICollection<MeetingParticipant> MeetingParticipations { get; set; }

        public ICollection<QuotationApproval> QuotationApprovals { get; set; }

    }
}
