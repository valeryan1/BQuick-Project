using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class TaskToDoTemplate
    {
        public TaskToDoTemplate()
        {
            TaskToDos = new HashSet<TaskToDo>();
        }

        [Key]
        public int TemplateID { get; set; }

        [Required, StringLength(100)]
        public string TemplateName { get; set; }

        [Required, StringLength(50)]
        public string TaskType { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<TaskToDo> TaskToDos { get; set; }
    }
}
