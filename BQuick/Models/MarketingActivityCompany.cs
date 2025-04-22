using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class MarketingActivityCompany
    {
        [Key]
        public int ActivityCompanyID { get; set; }

        public int ActivityID { get; set; }

        public int CompanyID { get; set; }

        public int? ContactID { get; set; }

        [StringLength(255)]
        public string Notes { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("ActivityID")]
        public virtual MarketingActivity MarketingActivity { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("ContactID")]
        public virtual CustomerContact Contact { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }
    }
}
