using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Numerics;

namespace BQuick.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Simpan HANYA hash password!

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }

        public bool IsActive { get; set; } = true;

        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        // Properti Navigasi
        public virtual ICollection<RFQ> CreatedRFQs { get; set; }
        public virtual ICollection<RFQ> AssignedRFQsAsAdmin { get; set; }
        public virtual ICollection<RFQ> AssignedBySalesManagerRFQs { get; set; }
        public virtual ICollection<RFQ> PersonalResourceRFQs { get; set; }
        public virtual ICollection<PurchasingRequest> HandledPurchasingRequests { get; set; }
        public virtual ICollection<PurchasingRequest> CreatedPurchasingRequests { get; set; }
        public virtual ICollection<SurveyRequest> CreatedSurveyRequests { get; set; }
        public virtual ICollection<SurveyPIC> SurveyAssignments { get; set; }
        public virtual ICollection<MeetingRequest> LedMeetingRequests { get; set; }
        public virtual ICollection<MeetingRequest> CreatedMeetingRequests { get; set; }
        public virtual ICollection<MeetingPIC> MeetingAssignments { get; set; }
        public virtual ICollection<Quotation> PreparedQuotations { get; set; }
        public virtual ICollection<ApprovalHistory> ApprovalsMade { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<RFQAttachment> UploadedRFQAttachments { get; set; }
        public virtual ICollection<SurveyInstance> SubmittedSurveyInstances { get; set; }
        public virtual ICollection<SurveyDocumentation> UploadedSurveyDocumentations { get; set; }
        public virtual ICollection<SurveyReportInstance> GeneratedSurveyReports { get; set; }
        public virtual ICollection<SurveyReportInstance> TechReviewedSurveyReports { get; set; }
        public virtual ICollection<SurveyReportInstance> SalesReviewedSurveyReports { get; set; }
        public virtual ICollection<MeetingReportInstance> GeneratedMeetingReports { get; set; }
        public virtual ICollection<TechnicalCompetency> TechnicalCompetencies { get; set; }
        public virtual ICollection<Vendor> CreatedVendors { get; set; }
        public virtual ICollection<Quotation> SMApprovedQuotations { get; set; }
        public virtual ICollection<Quotation> TMApprovedQuotations { get; set; }
        public virtual ICollection<Quotation> DirectorApprovedQuotations { get; set; }

        public User()
        {
            CreatedRFQs = new HashSet<RFQ>();
            AssignedRFQsAsAdmin = new HashSet<RFQ>();
            AssignedBySalesManagerRFQs = new HashSet<RFQ>();
            PersonalResourceRFQs = new HashSet<RFQ>();
            HandledPurchasingRequests = new HashSet<PurchasingRequest>();
            CreatedPurchasingRequests = new HashSet<PurchasingRequest>();
            CreatedSurveyRequests = new HashSet<SurveyRequest>();
            SurveyAssignments = new HashSet<SurveyPIC>();
            LedMeetingRequests = new HashSet<MeetingRequest>();
            CreatedMeetingRequests = new HashSet<MeetingRequest>();
            MeetingAssignments = new HashSet<MeetingPIC>();
            PreparedQuotations = new HashSet<Quotation>();
            ApprovalsMade = new HashSet<ApprovalHistory>();
            Notifications = new HashSet<Notification>();
            UploadedRFQAttachments = new HashSet<RFQAttachment>();
            SubmittedSurveyInstances = new HashSet<SurveyInstance>();
            UploadedSurveyDocumentations = new HashSet<SurveyDocumentation>();
            GeneratedSurveyReports = new HashSet<SurveyReportInstance>();
            TechReviewedSurveyReports = new HashSet<SurveyReportInstance>();
            SalesReviewedSurveyReports = new HashSet<SurveyReportInstance>();
            GeneratedMeetingReports = new HashSet<MeetingReportInstance>();
            TechnicalCompetencies = new HashSet<TechnicalCompetency>();
            CreatedVendors = new HashSet<Vendor>();
            SMApprovedQuotations = new HashSet<Quotation>();
            TMApprovedQuotations = new HashSet<Quotation>();
            DirectorApprovedQuotations = new HashSet<Quotation>();
        }
    }
}