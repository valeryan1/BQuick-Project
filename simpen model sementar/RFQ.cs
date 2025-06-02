using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{
    public class RFQ
    {
        [Key]
        public int RFQID { get; set; }

        [Required]
        [StringLength(50)]
        public string RFQCode { get; set; } // Unik, diindeks

        [Required]
        [StringLength(255)]
        public string RFQName { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public int? ContactPersonID { get; set; }
        [ForeignKey("ContactPersonID")]
        public virtual CustomerContactPerson ContactPerson { get; set; }

        public DateTime RequestDate { get; set; }
        public DateTime DueDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OverallBudget { get; set; }
        [StringLength(100)]
        public string OverallLeadTime { get; set; } // Misalnya "4-6 Weeks"

        [StringLength(50)]
        public string Resource { get; set; } // Email, Whatsapp
        public int? PersonalResourceEmployeeID { get; set; } // FK ke User
        [ForeignKey("PersonalResourceEmployeeID")]
        public virtual User PersonalResourceEmployee { get; set; }

        public int RFQCategoryID { get; set; } // FK ke RFQCategory
        [ForeignKey("RFQCategoryID")]
        public virtual RFQCategory RFQCategory { get; set; }

        public int RFQOpportunityID { get; set; } // FK ke RFQOpportunity
        [ForeignKey("RFQOpportunityID")]
        public virtual RFQOpportunity RFQOpportunity { get; set; }

        public int RFQStatusID { get; set; } // FK ke RFQStatus
        [ForeignKey("RFQStatusID")]
        public virtual RFQStatus RFQStatus { get; set; }

        public int CreatedByUserID { get; set; }
        [ForeignKey("CreatedByUserID")]
        public virtual User CreatedByUser { get; set; }

        public int? AssignedToAdminSalesID { get; set; }
        [ForeignKey("AssignedToAdminSalesID")]
        public virtual User AssignedToAdminSales { get; set; }

        public int? SalesManagerAssignerID { get; set; }
        [ForeignKey("SalesManagerAssignerID")]
        public virtual User SalesManagerAssigner { get; set; }

        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdateTimestamp { get; set; } = DateTime.UtcNow;

        public virtual ICollection<RFQNote> Notes { get; set; }
        public virtual ICollection<RFQAttachment> Attachments { get; set; }
        public virtual ICollection<RFQ_Item> Items { get; set; }
        public virtual ICollection<PurchasingRequest> PurchasingRequests { get; set; }
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
        public virtual ICollection<MeetingRequest> MeetingRequests { get; set; }
        public virtual ICollection<Quotation> Quotations { get; set; }

        public RFQ()
        {
            Notes = new HashSet<RFQNote>();
            Attachments = new HashSet<RFQAttachment>();
            Items = new HashSet<RFQ_Item>();
            PurchasingRequests = new HashSet<PurchasingRequest>();
            SurveyRequests = new HashSet<SurveyRequest>();
            MeetingRequests = new HashSet<MeetingRequest>();
            Quotations = new HashSet<Quotation>();
        }
    }
}