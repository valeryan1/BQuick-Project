using Microsoft.EntityFrameworkCore;
using BQuick.Models;

namespace BQuick.Data
{
    public class BQuickDbContext : DbContext
    {
        public BQuickDbContext(DbContextOptions<BQuickDbContext> options)
            : base(options)
        {
        }

        // User and Department
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments { get; set; }

        // Company and Contact
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyAttachment> CompanyAttachments { get; set; }
        public DbSet<CustomerContact> CustomerContacts { get; set; }

        // Item and Vendor
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorBankAccount> VendorBankAccounts { get; set; }
        public DbSet<VendorAttachment> VendorAttachments { get; set; }
        public DbSet<ItemVendor> ItemVendors { get; set; }

        // RFQ
        public DbSet<RFQ> RFQs { get; set; }
        public DbSet<RFQItem> RFQItems { get; set; }
        public DbSet<RFQItemAddOn> RFQItemAddOns { get; set; }
        public DbSet<RFQNotesItem> RFQNotesItems { get; set; }
        public DbSet<RFQAttachment> RFQAttachments { get; set; }

        // Request Item
        public DbSet<RequestItem> RequestItems { get; set; }
        public DbSet<RequestItemAttachment> RequestItemAttachments { get; set; }
        public DbSet<RequestItemResponse> RequestItemResponses { get; set; }

        // Survey
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyPIC> SurveyPICs { get; set; }
        public DbSet<SurveyForm> SurveyForms { get; set; }
        public DbSet<SurveyResult> SurveyResults { get; set; }
        public DbSet<SurveyAttachment> SurveyAttachments { get; set; }

        // Report
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportAttachment> ReportAttachments { get; set; }

        // Meeting
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingPIC> MeetingPICs { get; set; }
        public DbSet<MeetingExternalParticipant> MeetingExternalParticipants { get; set; }
        public DbSet<MeetingAttachment> MeetingAttachments { get; set; }
        public DbSet<MeetingMinute> MeetingMinutes { get; set; }

        // Quotation
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<QuotationAttachment> QuotationAttachments { get; set; }
        public DbSet<QuotationHistory> QuotationHistories { get; set; }

        // PMO Assignment
        public DbSet<PMOAssignment> PMOAssignments { get; set; }

        // Marketing and Business Development
        public DbSet<MarketingActivity> MarketingActivities { get; set; }
        public DbSet<MarketingActivityCompany> MarketingActivityCompanies { get; set; }
        public DbSet<BusinessDevelopmentActivity> BusinessDevelopmentActivities { get; set; }

        // Inventory
        public DbSet<InventoryMovement> InventoryMovements { get; set; }

        // Notification and Task
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TaskToDoTemplate> TaskToDoTemplates { get; set; }
        public DbSet<TaskToDo> TaskToDos { get; set; }

        // Audit
        public DbSet<AuditLog> AuditLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Company>()
                .HasIndex(c => c.CompanyCode)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .HasIndex(i => i.ItemCode)
                .IsUnique();

            modelBuilder.Entity<Vendor>()
                .HasIndex(v => v.VendorCode)
                .IsUnique();

            modelBuilder.Entity<RFQ>()
                .HasIndex(r => r.RFQCode)
                .IsUnique();

            modelBuilder.Entity<Survey>()
                .HasIndex(s => s.SurveyCode)
                .IsUnique();

            modelBuilder.Entity<Quotation>()
                .HasIndex(q => q.QuotationNumber)
                .IsUnique();

            // Configure relationships for User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Manager)
                .WithMany(m => m.Subordinates)
                .HasForeignKey(u => u.ReportsToID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.ModifiedBy)
                .WithMany()
                .HasForeignKey(u => u.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Company
            modelBuilder.Entity<Company>()
                .HasOne(c => c.AccountManager)
                .WithMany()
                .HasForeignKey(c => c.AccountManagerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.CreatedBy)
                .WithMany(u => u.CreatedCompanies)
                .HasForeignKey(c => c.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Company>()
                .HasOne(c => c.ModifiedBy)
                .WithMany(u => u.ModifiedCompanies)
                .HasForeignKey(c => c.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Department
            modelBuilder.Entity<Department>()
                .HasOne(d => d.DepartmentHead)
                .WithMany()
                .HasForeignKey(d => d.DepartmentHeadID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.CreatedBy)
                .WithMany()
                .HasForeignKey(d => d.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(d => d.ModifiedBy)
                .WithMany()
                .HasForeignKey(d => d.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for UserDepartment
            modelBuilder.Entity<UserDepartment>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDepartments)
                .HasForeignKey(ud => ud.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDepartment>()
                .HasOne(ud => ud.Department)
                .WithMany(d => d.UserDepartments)
                .HasForeignKey(ud => ud.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDepartment>()
                .HasOne(ud => ud.CreatedBy)
                .WithMany()
                .HasForeignKey(ud => ud.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for CustomerContact
            modelBuilder.Entity<CustomerContact>()
                .HasOne(cc => cc.Company)
                .WithMany(c => c.CustomerContacts)
                .HasForeignKey(cc => cc.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerContact>()
                .HasOne(cc => cc.CreatedBy)
                .WithMany()
                .HasForeignKey(cc => cc.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerContact>()
                .HasOne(cc => cc.ModifiedBy)
                .WithMany()
                .HasForeignKey(cc => cc.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for CompanyAttachment
            modelBuilder.Entity<CompanyAttachment>()
                .HasOne(ca => ca.Company)
                .WithMany(c => c.CompanyAttachments)
                .HasForeignKey(ca => ca.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyAttachment>()
                .HasOne(ca => ca.UploadedBy)
                .WithMany()
                .HasForeignKey(ca => ca.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Item
            modelBuilder.Entity<Item>()
                .HasOne(i => i.CreatedBy)
                .WithMany()
                .HasForeignKey(i => i.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.ModifiedBy)
                .WithMany()
                .HasForeignKey(i => i.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for ItemImage
            modelBuilder.Entity<ItemImage>()
                .HasOne(ii => ii.Item)
                .WithMany(i => i.ItemImages)
                .HasForeignKey(ii => ii.ItemID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemImage>()
                .HasOne(ii => ii.UploadedBy)
                .WithMany()
                .HasForeignKey(ii => ii.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Vendor
            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.PurchasingManager)
                .WithMany()
                .HasForeignKey(v => v.PurchasingManagerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.CreatedBy)
                .WithMany()
                .HasForeignKey(v => v.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.ModifiedBy)
                .WithMany()
                .HasForeignKey(v => v.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for VendorBankAccount
            modelBuilder.Entity<VendorBankAccount>()
                .HasOne(vba => vba.Vendor)
                .WithMany(v => v.VendorBankAccounts)
                .HasForeignKey(vba => vba.VendorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VendorBankAccount>()
                .HasOne(vba => vba.CreatedBy)
                .WithMany()
                .HasForeignKey(vba => vba.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VendorBankAccount>()
                .HasOne(vba => vba.ModifiedBy)
                .WithMany()
                .HasForeignKey(vba => vba.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for VendorAttachment
            modelBuilder.Entity<VendorAttachment>()
                .HasOne(va => va.Vendor)
                .WithMany(v => v.VendorAttachments)
                .HasForeignKey(va => va.VendorID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VendorAttachment>()
                .HasOne(va => va.UploadedBy)
                .WithMany()
                .HasForeignKey(va => va.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for ItemVendor
            modelBuilder.Entity<ItemVendor>()
                .HasOne(iv => iv.Item)
                .WithMany(i => i.ItemVendors)
                .HasForeignKey(iv => iv.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemVendor>()
                .HasOne(iv => iv.Vendor)
                .WithMany(v => v.ItemVendors)
                .HasForeignKey(iv => iv.VendorID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemVendor>()
                .HasOne(iv => iv.CreatedBy)
                .WithMany()
                .HasForeignKey(iv => iv.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemVendor>()
                .HasOne(iv => iv.ModifiedBy)
                .WithMany()
                .HasForeignKey(iv => iv.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RFQ
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.Company)
                .WithMany(c => c.RFQs)
                .HasForeignKey(r => r.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.Contact)
                .WithMany(c => c.RFQs)
                .HasForeignKey(r => r.ContactID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.AdminSales)
                .WithMany(u => u.AssignedRFQsAsAdminSales)
                .HasForeignKey(r => r.AdminSalesID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.Sales)
                .WithMany(u => u.AssignedRFQsAsSales)
                .HasForeignKey(r => r.SalesID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.BusinessDevelopment)
                .WithMany(u => u.AssignedRFQsAsBusinessDevelopment)
                .HasForeignKey(r => r.BusinessDevelopmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.PreSalesSupport)
                .WithMany(u => u.AssignedRFQsAsPreSalesSupport)
                .HasForeignKey(r => r.PreSalesSupportID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.PMO)
                .WithMany(u => u.AssignedRFQsAsPMO)
                .HasForeignKey(r => r.PMOID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.ModifiedBy)
                .WithMany()
                .HasForeignKey(r => r.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RFQItem
            modelBuilder.Entity<RFQItem>()
                .HasOne(ri => ri.RFQ)
                .WithMany(r => r.RFQItems)
                .HasForeignKey(ri => ri.RFQID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RFQItem>()
                .HasOne(ri => ri.Item)
                .WithMany(i => i.RFQItems)
                .HasForeignKey(ri => ri.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQItem>()
                .HasOne(ri => ri.CreatedBy)
                .WithMany()
                .HasForeignKey(ri => ri.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQItem>()
                .HasOne(ri => ri.ModifiedBy)
                .WithMany()
                .HasForeignKey(ri => ri.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RFQItemAddOn
            modelBuilder.Entity<RFQItemAddOn>()
                .HasOne(ria => ria.RFQItem)
                .WithMany(ri => ri.RFQItemAddOns)
                .HasForeignKey(ria => ria.RFQItemID)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure relationships for RFQNotesItem
            modelBuilder.Entity<RFQNotesItem>()
                .HasOne(rni => rni.RFQ)
                .WithMany(r => r.RFQNotesItems)
                .HasForeignKey(rni => rni.RFQID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RFQNotesItem>()
                .HasOne(rni => rni.CreatedBy)
                .WithMany()
                .HasForeignKey(rni => rni.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQNotesItem>()
                .HasOne(rni => rni.ModifiedBy)
                .WithMany()
                .HasForeignKey(rni => rni.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RFQAttachment
            modelBuilder.Entity<RFQAttachment>()
                .HasOne(ra => ra.RFQ)
                .WithMany(r => r.RFQAttachments)
                .HasForeignKey(ra => ra.RFQID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RFQAttachment>()
                .HasOne(ra => ra.UploadedBy)
                .WithMany()
                .HasForeignKey(ra => ra.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RequestItem
            modelBuilder.Entity<RequestItem>()
                .HasOne(ri => ri.RFQ)
                .WithMany(r => r.RequestItems)
                .HasForeignKey(ri => ri.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestItem>()
                .HasOne(ri => ri.RequestedBy)
                .WithMany()
                .HasForeignKey(ri => ri.RequestedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestItem>()
                .HasOne(ri => ri.AssignedTo)
                .WithMany()
                .HasForeignKey(ri => ri.AssignedToID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestItem>()
                .HasOne(ri => ri.CreatedBy)
                .WithMany()
                .HasForeignKey(ri => ri.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RequestItem>()
                .HasOne(ri => ri.ModifiedBy)
                .WithMany()
                .HasForeignKey(ri => ri.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RequestItemAttachment
            modelBuilder.Entity<RequestItemAttachment>()
                .HasOne(ria => ria.RequestItem)
                .WithMany(ri => ri.RequestItemAttachments)
                .HasForeignKey(ria => ria.RequestItemID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestItemAttachment>()
                .HasOne(ria => ria.UploadedBy)
                .WithMany()
                .HasForeignKey(ria => ria.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for RequestItemResponse
            modelBuilder.Entity<RequestItemResponse>()
                .HasOne(rir => rir.RequestItem)
                .WithMany(ri => ri.RequestItemResponses)
                .HasForeignKey(rir => rir.RequestItemID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RequestItemResponse>()
                .HasOne(rir => rir.RespondedBy)
                .WithMany()
                .HasForeignKey(rir => rir.RespondedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Survey
            modelBuilder.Entity<Survey>()
                .HasOne(s => s.RFQ)
                .WithMany(r => r.Surveys)
                .HasForeignKey(s => s.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.CreatedBy)
                .WithMany()
                .HasForeignKey(s => s.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Survey>()
                .HasOne(s => s.ModifiedBy)
                .WithMany()
                .HasForeignKey(s => s.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for SurveyPIC
            modelBuilder.Entity<SurveyPIC>()
                .HasOne(sp => sp.Survey)
                .WithMany(s => s.SurveyPICs)
                .HasForeignKey(sp => sp.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SurveyPIC>()
                .HasOne(sp => sp.User)
                .WithMany()
                .HasForeignKey(sp => sp.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyPIC>()
                .HasOne(sp => sp.CreatedBy)
                .WithMany()
                .HasForeignKey(sp => sp.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for SurveyForm
            modelBuilder.Entity<SurveyForm>()
                .HasOne(sf => sf.Survey)
                .WithMany(s => s.SurveyForms)
                .HasForeignKey(sf => sf.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SurveyForm>()
                .HasOne(sf => sf.CreatedBy)
                .WithMany()
                .HasForeignKey(sf => sf.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyForm>()
                .HasOne(sf => sf.ModifiedBy)
                .WithMany()
                .HasForeignKey(sf => sf.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for SurveyResult
            modelBuilder.Entity<SurveyResult>()
                .HasOne(sr => sr.Survey)
                .WithMany(s => s.SurveyResults)
                .HasForeignKey(sr => sr.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SurveyResult>()
                .HasOne(sr => sr.CreatedBy)
                .WithMany()
                .HasForeignKey(sr => sr.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyResult>()
                .HasOne(sr => sr.ModifiedBy)
                .WithMany()
                .HasForeignKey(sr => sr.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for SurveyAttachment
            modelBuilder.Entity<SurveyAttachment>()
                .HasOne(sa => sa.Survey)
                .WithMany(s => s.SurveyAttachments)
                .HasForeignKey(sa => sa.SurveyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SurveyAttachment>()
                .HasOne(sa => sa.UploadedBy)
                .WithMany()
                .HasForeignKey(sa => sa.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Report
            modelBuilder.Entity<Report>()
                .HasOne(r => r.RFQ)
                .WithMany()
                .HasForeignKey(r => r.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.Survey)
                .WithMany()
                .HasForeignKey(r => r.SurveyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.CreatedBy)
                .WithMany()
                .HasForeignKey(r => r.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Report>()
                .HasOne(r => r.ModifiedBy)
                .WithMany()
                .HasForeignKey(r => r.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for ReportAttachment
            modelBuilder.Entity<ReportAttachment>()
                .HasOne(ra => ra.Report)
                .WithMany(r => r.ReportAttachments)
                .HasForeignKey(ra => ra.ReportID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReportAttachment>()
                .HasOne(ra => ra.UploadedBy)
                .WithMany()
                .HasForeignKey(ra => ra.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Meeting
            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.RFQ)
                .WithMany(r => r.Meetings)
                .HasForeignKey(m => m.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.OrganizedBy)
                .WithMany()
                .HasForeignKey(m => m.OrganizedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.CreatedBy)
                .WithMany()
                .HasForeignKey(m => m.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Meeting>()
                .HasOne(m => m.ModifiedBy)
                .WithMany()
                .HasForeignKey(m => m.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for MeetingPIC
            modelBuilder.Entity<MeetingPIC>()
                .HasOne(mp => mp.Meeting)
                .WithMany(m => m.MeetingPICs)
                .HasForeignKey(mp => mp.MeetingID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MeetingPIC>()
                .HasOne(mp => mp.User)
                .WithMany()
                .HasForeignKey(mp => mp.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for MeetingExternalParticipant
            modelBuilder.Entity<MeetingExternalParticipant>()
                .HasOne(mep => mep.Meeting)
                .WithMany(m => m.MeetingExternalParticipants)
                .HasForeignKey(mep => mep.MeetingID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MeetingExternalParticipant>()
                .HasOne(mep => mep.Contact)
                .WithMany()
                .HasForeignKey(mep => mep.ContactID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for MeetingAttachment
            modelBuilder.Entity<MeetingAttachment>()
                .HasOne(ma => ma.Meeting)
                .WithMany(m => m.MeetingAttachments)
                .HasForeignKey(ma => ma.MeetingID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MeetingAttachment>()
                .HasOne(ma => ma.UploadedBy)
                .WithMany()
                .HasForeignKey(ma => ma.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for MeetingMinute
            modelBuilder.Entity<MeetingMinute>()
                .HasOne(mm => mm.Meeting)
                .WithMany(m => m.MeetingMinutes)
                .HasForeignKey(mm => mm.MeetingID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MeetingMinute>()
                .HasOne(mm => mm.AssignedTo)
                .WithMany()
                .HasForeignKey(mm => mm.AssignedToID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeetingMinute>()
                .HasOne(mm => mm.CreatedBy)
                .WithMany()
                .HasForeignKey(mm => mm.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeetingMinute>()
                .HasOne(mm => mm.ModifiedBy)
                .WithMany()
                .HasForeignKey(mm => mm.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Quotation
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.RFQ)
                .WithMany(r => r.Quotations)
                .HasForeignKey(q => q.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.PreparedBy)
                .WithMany()
                .HasForeignKey(q => q.PreparedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.ApprovedBy)
                .WithMany()
                .HasForeignKey(q => q.ApprovedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.CreatedBy)
                .WithMany()
                .HasForeignKey(q => q.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.ModifiedBy)
                .WithMany()
                .HasForeignKey(q => q.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for QuotationItem
            modelBuilder.Entity<QuotationItem>()
                .HasOne(qi => qi.Quotation)
                .WithMany(q => q.QuotationItems)
                .HasForeignKey(qi => qi.QuotationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuotationItem>()
                .HasOne(qi => qi.Item)
                .WithMany()
                .HasForeignKey(qi => qi.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for QuotationAttachment
            modelBuilder.Entity<QuotationAttachment>()
                .HasOne(qa => qa.Quotation)
                .WithMany(q => q.QuotationAttachments)
                .HasForeignKey(qa => qa.QuotationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuotationAttachment>()
                .HasOne(qa => qa.UploadedBy)
                .WithMany()
                .HasForeignKey(qa => qa.UploadedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for QuotationHistory
            modelBuilder.Entity<QuotationHistory>()
                .HasOne(qh => qh.Quotation)
                .WithMany(q => q.QuotationHistories)
                .HasForeignKey(qh => qh.QuotationID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<QuotationHistory>()
                .HasOne(qh => qh.ChangedBy)
                .WithMany()
                .HasForeignKey(qh => qh.ChangedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for PMOAssignment
            modelBuilder.Entity<PMOAssignment>()
                .HasOne(pa => pa.RFQ)
                .WithMany(r => r.PMOAssignments)
                .HasForeignKey(pa => pa.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PMOAssignment>()
                .HasOne(pa => pa.PMO)
                .WithMany()
                .HasForeignKey(pa => pa.PMOID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PMOAssignment>()
                .HasOne(pa => pa.AssignedBy)
                .WithMany()
                .HasForeignKey(pa => pa.AssignedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PMOAssignment>()
                .HasOne(pa => pa.ModifiedBy)
                .WithMany()
                .HasForeignKey(pa => pa.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for MarketingActivity
            modelBuilder.Entity<MarketingActivity>()
                .HasOne(ma => ma.ResponsibleUser)
                .WithMany()
                .HasForeignKey(ma => ma.ResponsibleUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MarketingActivity>()
                .HasOne(ma => ma.CreatedBy)
                .WithMany()
                .HasForeignKey(ma => ma.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MarketingActivity>()
                .HasOne(ma => ma.ModifiedBy)
                .WithMany()
                .HasForeignKey(ma => ma.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for MarketingActivityCompany
            modelBuilder.Entity<MarketingActivityCompany>()
                .HasOne(mac => mac.MarketingActivity)
                .WithMany(ma => ma.MarketingActivityCompanies)
                .HasForeignKey(mac => mac.ActivityID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MarketingActivityCompany>()
                .HasOne(mac => mac.Company)
                .WithMany()
                .HasForeignKey(mac => mac.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MarketingActivityCompany>()
                .HasOne(mac => mac.Contact)
                .WithMany()
                .HasForeignKey(mac => mac.ContactID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MarketingActivityCompany>()
                .HasOne(mac => mac.CreatedBy)
                .WithMany()
                .HasForeignKey(mac => mac.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for BusinessDevelopmentActivity
            modelBuilder.Entity<BusinessDevelopmentActivity>()
                .HasOne(bda => bda.RFQ)
                .WithMany()
                .HasForeignKey(bda => bda.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BusinessDevelopmentActivity>()
                .HasOne(bda => bda.Company)
                .WithMany()
                .HasForeignKey(bda => bda.CompanyID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BusinessDevelopmentActivity>()
                .HasOne(bda => bda.Contact)
                .WithMany()
                .HasForeignKey(bda => bda.ContactID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BusinessDevelopmentActivity>()
                .HasOne(bda => bda.PerformedBy)
                .WithMany()
                .HasForeignKey(bda => bda.PerformedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BusinessDevelopmentActivity>()
                .HasOne(bda => bda.CreatedBy)
                .WithMany()
                .HasForeignKey(bda => bda.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BusinessDevelopmentActivity>()
                .HasOne(bda => bda.ModifiedBy)
                .WithMany()
                .HasForeignKey(bda => bda.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for InventoryMovement
            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.Item)
                .WithMany()
                .HasForeignKey(im => im.ItemID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InventoryMovement>()
                .HasOne(im => im.PerformedBy)
                .WithMany()
                .HasForeignKey(im => im.PerformedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for Notification
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.CreatedBy)
                .WithMany()
                .HasForeignKey(n => n.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for TaskToDoTemplate
            modelBuilder.Entity<TaskToDoTemplate>()
                .HasOne(tdt => tdt.CreatedBy)
                .WithMany()
                .HasForeignKey(tdt => tdt.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskToDoTemplate>()
                .HasOne(tdt => tdt.ModifiedBy)
                .WithMany()
                .HasForeignKey(tdt => tdt.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for TaskToDo
            modelBuilder.Entity<TaskToDo>()
                .HasOne(ttd => ttd.Template)
                .WithMany(tdt => tdt.TaskToDos)
                .HasForeignKey(ttd => ttd.TemplateID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskToDo>()
                .HasOne(ttd => ttd.AssignedTo)
                .WithMany()
                .HasForeignKey(ttd => ttd.AssignedToID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskToDo>()
                .HasOne(ttd => ttd.AssignedBy)
                .WithMany()
                .HasForeignKey(ttd => ttd.AssignedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskToDo>()
                .HasOne(ttd => ttd.CreatedBy)
                .WithMany()
                .HasForeignKey(ttd => ttd.CreatedByID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskToDo>()
                .HasOne(ttd => ttd.ModifiedBy)
                .WithMany()
                .HasForeignKey(ttd => ttd.ModifiedByID)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure relationships for AuditLog
            modelBuilder.Entity<AuditLog>()
                .HasOne(al => al.User)
                .WithMany()
                .HasForeignKey(al => al.UserID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
