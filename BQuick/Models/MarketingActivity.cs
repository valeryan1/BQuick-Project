using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MarketingActivity
    {
        public MarketingActivity()
        {
            MarketingActivityCompanies = new HashSet<MarketingActivityCompany>();
        }

        [Key]
        public int ActivityID { get; set; }

        [Required, StringLength(255)]
        public string ActivityName { get; set; }

        [Required, StringLength(50)]
        public string ActivityType { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualCost { get; set; } = 0;

        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(255)]
        public string Outcome { get; set; }

        public int ResponsibleUserID { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ResponsibleUserID")]
        public virtual User ResponsibleUser { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<MarketingActivityCompany> MarketingActivityCompanies { get; set; }
    }
}
