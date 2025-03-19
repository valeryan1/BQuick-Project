using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    public class RFQNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteID { get; set; }

        [ForeignKey("RFQ")]
        public int RFQID { get; set; }
        public virtual RFQ RFQ { get; set; }

        [Required]
        public string NoteText { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedBy { get; set; }
        public virtual User User { get; set; }
    }
}
