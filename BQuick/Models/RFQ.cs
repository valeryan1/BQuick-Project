using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQ
    {
        public RFQ()
        {
            RFQItems = new HashSet<RFQItem>();
            RFQNotesItems = new HashSet<RFQNotesItem>();
            RFQAttachments = new HashSet<RFQAttachment>();
            RequestItems = new HashSet<RequestItem>();
            Surveys = new HashSet<Survey>();
            Meetings = new HashSet<Meeting>();
            Quotations = new HashSet<Quotation>();
            PMOAssignments = new HashSet<PMOAssignment>();
        }

        [Key]
        public int RFQID { get; set; }

        [Required, StringLength(20)]
        public string RFQCode { get; set; }

        [Required, StringLength(255)]
        public string RFQName { get; set; }

        public int CompanyID { get; set; }

        public int ContactID { get; set; }

        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Opportunity { get; set; }

        [StringLength(20)]
        public string Priority { get; set; }

        public int AdminSalesID { get; set; }

        public int SalesID { get; set; }

        public int? BusinessDevelopmentID { get; set; }

        public int? PreSalesSupportID { get; set; }

        public int? PMOID { get; set; }

        public string Notes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; } = 0;

        [Required, StringLength(50)]
        public string Status { get; set; } // Example: "Waiting Purc;Waiting Discuss"

        [Column(TypeName = "decimal(18,2)")]
        public decimal EstimatedValue { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal ActualValue { get; set; } = 0;

        public int WinProbability { get; set; } = 50;

        public DateTime? ExpectedClosingDate { get; set; }

        [StringLength(500)]
        public string CompetitorInfo { get; set; }

        public int CreatedByID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ModifiedByID { get; set; }

        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Navigation properties
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("ContactID")]
        public virtual CustomerContact Contact { get; set; }

        [ForeignKey("AdminSalesID")]
        public virtual User AdminSales { get; set; }

        [ForeignKey("SalesID")]
        public virtual User Sales { get; set; }

        [ForeignKey("BusinessDevelopmentID")]
        public virtual User BusinessDevelopment { get; set; }

        [ForeignKey("PreSalesSupportID")]
        public virtual User PreSalesSupport { get; set; }

        [ForeignKey("PMOID")]
        public virtual User PMO { get; set; }

        [ForeignKey("CreatedByID")]
        public virtual User CreatedBy { get; set; }

        [ForeignKey("ModifiedByID")]
        public virtual User ModifiedBy { get; set; }

        public virtual ICollection<RFQItem> RFQItems { get; set; }
        public virtual ICollection<RFQNotesItem> RFQNotesItems { get; set; }
        public virtual ICollection<RFQAttachment> RFQAttachments { get; set; }
        public virtual ICollection<RequestItem> RequestItems { get; set; }
        public virtual ICollection<Survey> Surveys { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }
        public virtual ICollection<PMOAssignment> PMOAssignments { get; set; }
    }
}
