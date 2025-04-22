using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class TaskToDo
    {
        [Key]
        public int TaskID { get; set; }

        public int? TemplateID { get; set; }

        [Required, StringLength(255)]
        public string TaskTitle { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required, StringLength(50)]
        public string TaskType { get; set; }

        [StringLength(50)]
        public string ReferenceType { get; set; }

        public int? ReferenceID { get; set; }

        [StringLength(50)]
        public string Priority { get; set; }

        public int AssignedToID { get; set; }

        public int? AssignedByID { get; set; }

        public DateTime DueDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public DateTime? CompletionDate { get; set; }

        [StringLength(500)]
        public string CompletionNotes { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("TemplateID")]
        public virtual TaskToDoTemplate Template { get; set; }

        [ForeignKey("AssignedToID")]
        public virtual User AssignedTo { get; set; }

        [ForeignKey("AssignedByID")]
        public virtual User AssignedBy { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }
    }
}
