using Microsoft.EntityFrameworkCore;
using BQuick.Models; // Pastikan namespace ini sesuai dengan tempat model Anda berada

namespace BQuick.Data
{
    public class BQuickDbContext : DbContext
    {
        public BQuickDbContext(DbContextOptions<BQuickDbContext> options) : base(options)
        {
        }

        // --- Entitas Inti & Pengguna ---
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<ReqItem2> ReqItem2 { get; set; } // Sesuai permintaan Anda

        // --- Entitas Terkait Pelanggan ---
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerContactPerson> CustomerContactPersons { get; set; }

        // --- Entitas Terkait Item & Vendor ---
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<ItemBundle> ItemBundles { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<VendorBank> VendorBanks { get; set; }
        public virtual DbSet<ItemVendorPricing> ItemVendorPricings { get; set; }

        // --- Entitas Terkait RFQ ---
        public virtual DbSet<RFQ> RFQs { get; set; }
        public virtual DbSet<RFQCategory> RFQCategories { get; set; }
        public virtual DbSet<RFQOpportunity> RFQOpportunities { get; set; }
        public virtual DbSet<RFQStatus> RFQStatuses { get; set; }
        public virtual DbSet<RFQNote> RFQNotes { get; set; }
        public virtual DbSet<RFQAttachment> RFQAttachments { get; set; }
        public virtual DbSet<RFQ_Item> RFQ_Items { get; set; }

        // --- Entitas Terkait Purchasing ---
        public virtual DbSet<PurchasingRequest> PurchasingRequests { get; set; }
        public virtual DbSet<PurchasingStatus> PurchasingStatuses { get; set; }

        // --- Entitas Terkait Survei ---
        public virtual DbSet<SurveyCategory> SurveyCategories { get; set; }
        public virtual DbSet<TechnicalCompetency> TechnicalCompetencies { get; set; }
        public virtual DbSet<SurveyRequest> SurveyRequests { get; set; }
        public virtual DbSet<SurveyStatus> SurveyStatuses { get; set; }
        public virtual DbSet<SurveyPIC> SurveyPICs { get; set; }
        public virtual DbSet<PICApprovalStatus> PICApprovalStatuses { get; set; }
        public virtual DbSet<SurveyFormMaster> SurveyFormMasters { get; set; }
        public virtual DbSet<SurveyInstance> SurveyInstances { get; set; }
        public virtual DbSet<SurveyDocumentation> SurveyDocumentations { get; set; }
        public virtual DbSet<ReportMaster> ReportMasters { get; set; }
        public virtual DbSet<SurveyReportInstance> SurveyReportInstances { get; set; }
        public virtual DbSet<ReportStatus> ReportStatuses { get; set; }

        // --- Entitas Terkait Meeting ---
        public virtual DbSet<MeetingRequest> MeetingRequests { get; set; }
        public virtual DbSet<MeetingStatus> MeetingStatuses { get; set; }
        public virtual DbSet<MeetingPIC> MeetingPICs { get; set; }
        public virtual DbSet<MeetingReportInstance> MeetingReportInstances { get; set; }

        // --- Entitas Terkait Quotation ---
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        public virtual DbSet<ShipmentTerm> ShipmentTerms { get; set; }
        public virtual DbSet<QuotationStatus> QuotationStatuses { get; set; }
        public virtual DbSet<QuotationItem> QuotationItems { get; set; }

        // --- Entitas Generik untuk Persetujuan & Notifikasi ---
        public virtual DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        public virtual DbSet<ApprovalDecisionStatus> ApprovalDecisionStatuses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Konfigurasi Composite Keys ---
            modelBuilder.Entity<TechnicalCompetency>()
                .HasKey(tc => new { tc.UserID, tc.SurveyCategoryID });

            // --- Konfigurasi Indexes ---
            ConfigureIndexes(modelBuilder);

            // --- Konfigurasi Delete Behaviors ---

            // ItemBundle ke Item (Mencegah siklus cascade)
            modelBuilder.Entity<ItemBundle>()
                .HasOne(ib => ib.ParentItem)
                .WithMany(i => i.ParentBundleItems)
                .HasForeignKey(ib => ib.ParentItemID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemBundle>()
                .HasOne(ib => ib.ChildItem)
                .WithMany(i => i.ChildBundleItems)
                .HasForeignKey(ib => ib.ChildItemID)
                .OnDelete(DeleteBehavior.Restrict);

            // User ke Role (Mencegah Role dihapus jika ada User)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            // Vendor.CreatedByUserID (Jika User pembuat dihapus, set FK ke null)
            modelBuilder.Entity<Vendor>()
                .HasOne(v => v.CreatedByUser)
                .WithMany(u => u.CreatedVendors)
                .HasForeignKey(v => v.CreatedByUserID)
                .OnDelete(DeleteBehavior.SetNull); // FK CreatedByUserID di Vendor adalah nullable

            // RFQ Relasi ke Customer
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.RFQs)
                .HasForeignKey(r => r.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            // **PERUBAHAN KUNCI DI SINI: Semua FK dari RFQ ke User menjadi Restrict**
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.CreatedByUser)
                .WithMany(u => u.CreatedRFQs)
                .HasForeignKey(r => r.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.AssignedToAdminSales)
                .WithMany(u => u.AssignedRFQsAsAdmin)
                .HasForeignKey(r => r.AssignedToAdminSalesID)
                .OnDelete(DeleteBehavior.Restrict); // Diubah dari SetNull

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.SalesManagerAssigner)
                .WithMany(u => u.AssignedBySalesManagerRFQs)
                .HasForeignKey(r => r.SalesManagerAssignerID)
                .OnDelete(DeleteBehavior.Restrict); // Diubah dari SetNull

            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.PersonalResourceEmployee)
                .WithMany(u => u.PersonalResourceRFQs)
                .HasForeignKey(r => r.PersonalResourceEmployeeID)
                .OnDelete(DeleteBehavior.Restrict); // Diubah dari SetNull
            // **********************************************************************

            // RFQ Relasi lain
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.ContactPerson)
                .WithMany()
                .HasForeignKey(r => r.ContactPersonID)
                .OnDelete(DeleteBehavior.SetNull);

            // RFQ_Item Relasi
            modelBuilder.Entity<RFQ_Item>()
               .HasOne(ri => ri.ChosenVendor)
               .WithMany()
               .HasForeignKey(ri => ri.ChosenVendorID)
               .OnDelete(DeleteBehavior.SetNull);

            // PurchasingRequest Relasi ke User
            modelBuilder.Entity<PurchasingRequest>()
                .HasOne(pr => pr.RequestedByUser)
                .WithMany(u => u.CreatedPurchasingRequests)
                .HasForeignKey(pr => pr.RequestedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PurchasingRequest>()
                .HasOne(pr => pr.AssignedToPurchasingUser)
                .WithMany(u => u.HandledPurchasingRequests)
                .HasForeignKey(pr => pr.AssignedToPurchasingUserID)
                .OnDelete(DeleteBehavior.SetNull);

            // SurveyRequest Relasi ke User
            modelBuilder.Entity<SurveyRequest>()
                .HasOne(sr => sr.CreatedByUser)
                .WithMany(u => u.CreatedSurveyRequests)
                .HasForeignKey(sr => sr.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // SurveyPIC Relasi ke User 
            modelBuilder.Entity<SurveyPIC>()
                .HasOne(sp => sp.TechnicalUser)
                .WithMany(u => u.SurveyAssignments)
                .HasForeignKey(sp => sp.TechnicalUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // SurveyInstance Relasi ke User 
            modelBuilder.Entity<SurveyInstance>()
                .HasOne(si => si.SubmittedByUser)
                .WithMany(u => u.SubmittedSurveyInstances)
                .HasForeignKey(si => si.SubmittedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // SurveyDocumentation Relasi ke User
            modelBuilder.Entity<SurveyDocumentation>()
                .HasOne(sd => sd.UploadedByUser)
                .WithMany(u => u.UploadedSurveyDocumentations)
                .HasForeignKey(sd => sd.UploadedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // SurveyReportInstance Relasi ke SurveyInstance
            modelBuilder.Entity<SurveyReportInstance>()
                .HasOne(sri => sri.SurveyInstance)
                .WithMany(si => si.Reports)
                .HasForeignKey(sri => sri.SurveyInstanceID)
                .OnDelete(DeleteBehavior.Restrict);

            // SurveyReportInstance Relasi ke ReportMaster
            modelBuilder.Entity<SurveyReportInstance>()
                .HasOne(sri => sri.ReportMaster)
                .WithMany(rm => rm.SurveyReportInstances)
                .HasForeignKey(sri => sri.ReportMasterID)
                .OnDelete(DeleteBehavior.Restrict);

            // SurveyReportInstance Relasi ke User (Semua diatur ke Restrict untuk FK ke User)
            modelBuilder.Entity<SurveyReportInstance>()
                .HasOne(sri => sri.GeneratedByUser)
                .WithMany(u => u.GeneratedSurveyReports)
                .HasForeignKey(sri => sri.GeneratedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyReportInstance>()
                .HasOne(sri => sri.TechManagerReviewer)
                .WithMany(u => u.TechReviewedSurveyReports)
                .HasForeignKey(sri => sri.TechManagerReviewerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SurveyReportInstance>()
                .HasOne(sri => sri.SalesManagerReviewer)
                .WithMany(u => u.SalesReviewedSurveyReports)
                .HasForeignKey(sri => sri.SalesManagerReviewerID)
                .OnDelete(DeleteBehavior.Restrict);

            // MeetingRequest Relasi ke User (Mencegah siklus cascade)
            modelBuilder.Entity<MeetingRequest>()
                .HasOne(mr => mr.CreatedByUser)
                .WithMany(u => u.CreatedMeetingRequests)
                .HasForeignKey(mr => mr.CreatedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MeetingRequest>()
                .HasOne(mr => mr.PrimaryPIC_User)
                .WithMany(u => u.LedMeetingRequests)
                .HasForeignKey(mr => mr.PrimaryPIC_UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Quotation Relasi ke User
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.PreparedByUser)
                .WithMany(u => u.PreparedQuotations)
                .HasForeignKey(q => q.PreparedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.SalesManagerApprover)
                .WithMany(u => u.SMApprovedQuotations)
                .HasForeignKey(q => q.SalesManagerApproverID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.TechnicalManagerApprover)
                .WithMany(u => u.TMApprovedQuotations)
                .HasForeignKey(q => q.TechnicalManagerApproverID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.DirectorApprover)
                .WithMany(u => u.DirectorApprovedQuotations)
                .HasForeignKey(q => q.DirectorApproverID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relasi Quotation ke RFQ
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.RFQ)
                .WithMany(r => r.Quotations)
                .HasForeignKey(q => q.RFQID)
                .OnDelete(DeleteBehavior.Restrict);

            // Item Relasi
            modelBuilder.Entity<Item>()
                .HasOne(i => i.ItemType)
                .WithMany(it => it.Items)
                .HasForeignKey(i => i.ItemTypeID)
                .OnDelete(DeleteBehavior.SetNull);

            // Quotation Split (Mencegah parent dihapus jika ada child)
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.SplitParentQuotation)
                .WithMany(pq => pq.SplitChildQuotations)
                .HasForeignKey(q => q.SplitParentQuotationID)
                .OnDelete(DeleteBehavior.Restrict);

            // ApprovalHistory Relasi ke User (Jangan hapus User jika ada histori approval)
            modelBuilder.Entity<ApprovalHistory>()
                .HasOne(ah => ah.ApproverUser)
                .WithMany(u => u.ApprovalsMade)
                .HasForeignKey(ah => ah.ApproverUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>(entity =>
            {
                // Menentukan presisi untuk properti desimal agar tidak ada data yang terpotong
                // HasPrecision(18, 4) berarti total 18 digit, dengan 4 digit di belakang koma.
                entity.Property(e => e.DimensionL).HasPrecision(18, 4);
                entity.Property(e => e.DimensionW).HasPrecision(18, 4);
                entity.Property(e => e.DimensionH).HasPrecision(18, 4);
                entity.Property(e => e.Weight).HasPrecision(18, 4);
            });
            // Konfigurasi untuk tabel lookup (mencegah penghapusan jika masih digunakan)
            ConfigureRestrictDeleteForLookupTables(modelBuilder);
        }

        private void ConfigureIndexes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.RoleName)
                .IsUnique();

            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.CustomerCode)
                .IsUnique()
                .HasFilter("[CustomerCode] IS NOT NULL");

            modelBuilder.Entity<Item>()
                .HasIndex(i => i.ItemCode)
                .IsUnique();

            modelBuilder.Entity<ItemCategory>()
                .HasIndex(ic => ic.CategoryName)
                .IsUnique();

            modelBuilder.Entity<ItemType>()
                .HasIndex(it => new { it.ItemCategoryID, it.ItemTypeName })
                .IsUnique();

            modelBuilder.Entity<Vendor>()
                .HasIndex(v => v.VendorCode)
                .IsUnique()
                .HasFilter("[VendorCode] IS NOT NULL");

            modelBuilder.Entity<RFQ>()
                .HasIndex(r => r.RFQCode)
                .IsUnique();

            modelBuilder.Entity<RFQCategory>()
                .HasIndex(rc => rc.Name)
                .IsUnique();
            modelBuilder.Entity<RFQOpportunity>()
                .HasIndex(ro => ro.Name)
                .IsUnique();
            modelBuilder.Entity<RFQStatus>()
                .HasIndex(rs => rs.Name)
                .IsUnique();

            modelBuilder.Entity<PurchasingStatus>()
                .HasIndex(ps => ps.Name)
                .IsUnique();

            modelBuilder.Entity<SurveyCategory>()
                .HasIndex(sc => sc.CategoryName)
                .IsUnique();
            modelBuilder.Entity<SurveyRequest>()
                .HasIndex(sr => sr.SurveyCode)
                .IsUnique();
            modelBuilder.Entity<SurveyStatus>()
                .HasIndex(ss => ss.Name)
                .IsUnique();
            modelBuilder.Entity<PICApprovalStatus>()
                .HasIndex(pas => pas.Name)
                .IsUnique();
            modelBuilder.Entity<SurveyFormMaster>()
                .HasIndex(sfm => sfm.FormName)
                .IsUnique();
            modelBuilder.Entity<ReportMaster>()
                .HasIndex(rm => rm.ReportName)
                .IsUnique();
            modelBuilder.Entity<ReportStatus>()
                .HasIndex(rs => rs.Name)
                .IsUnique();

            modelBuilder.Entity<MeetingRequest>()
                .HasIndex(mr => mr.MeetingCode)
                .IsUnique();
            modelBuilder.Entity<MeetingStatus>()
                .HasIndex(ms => ms.Name)
                .IsUnique();

            modelBuilder.Entity<Quotation>()
                .HasIndex(q => q.QuotationCode)
                .IsUnique();
            modelBuilder.Entity<PaymentTerm>()
                .HasIndex(pt => pt.Name)
                .IsUnique();
            modelBuilder.Entity<ShipmentTerm>()
                .HasIndex(st => st.Name)
                .IsUnique();
            modelBuilder.Entity<QuotationStatus>()
                .HasIndex(qs => qs.Name)
                .IsUnique();

            modelBuilder.Entity<ApprovalDecisionStatus>()
                .HasIndex(ads => ads.Name)
                .IsUnique();

            modelBuilder.Entity<Setting>()
                .HasIndex(s => new { s.SettingGroup, s.SettingKey })
                .IsUnique();
        }

        private void ConfigureRestrictDeleteForLookupTables(ModelBuilder modelBuilder)
        {
            // RFQ Lookups
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.RFQCategory)
                .WithMany(rc => rc.RFQs)
                .HasForeignKey(r => r.RFQCategoryID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.RFQOpportunity)
                .WithMany(ro => ro.RFQs)
                .HasForeignKey(r => r.RFQOpportunityID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RFQ>()
                .HasOne(r => r.RFQStatus)
                .WithMany(rs => rs.RFQs)
                .HasForeignKey(r => r.RFQStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Purchasing Lookup
            modelBuilder.Entity<PurchasingRequest>()
                .HasOne(pr => pr.PurchasingStatus)
                .WithMany(ps => ps.PurchasingRequests)
                .HasForeignKey(pr => pr.PurchasingStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Survey Lookups
            /*modelBuilder.Entity<SurveyRequest>()
               .HasOne(sr => sr.SurveyCategory)
               .WithMany(sc => sc.SurveyRequests)
               .HasForeignKey(sr => sr.SurveyCategoryID)
               .OnDelete(DeleteBehavior.Restrict);*/
            modelBuilder.Entity<SurveyRequest>()
                .HasOne(sr => sr.SurveyStatus)
                .WithMany(ss => ss.SurveyRequests)
                .HasForeignKey(sr => sr.SurveyStatusID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SurveyPIC>()
                .HasOne(sp => sp.PICApprovalStatus)
                .WithMany(pas => pas.SurveyPICs)
                .HasForeignKey(sp => sp.PICApprovalStatusID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<SurveyReportInstance>()
                .HasOne(sri => sri.ReportStatus)
                .WithMany(rs => rs.SurveyReportInstances)
                .HasForeignKey(sri => sri.ReportStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Meeting Lookups
            modelBuilder.Entity<MeetingRequest>()
                .HasOne(mr => mr.MeetingStatus)
                .WithMany(ms => ms.MeetingRequests)
                .HasForeignKey(mr => mr.MeetingStatusID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MeetingPIC>()
               .HasOne(mp => mp.PICApprovalStatus)
               .WithMany(pas => pas.MeetingPICs)
               .HasForeignKey(mp => mp.PICApprovalStatusID)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MeetingReportInstance>()
                .HasOne(mri => mri.ReportStatus)
                .WithMany(rs => rs.MeetingReportInstances)
                .HasForeignKey(mri => mri.ReportStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Quotation Lookups
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.PaymentTerm)
                .WithMany(pt => pt.Quotations)
                .HasForeignKey(q => q.PaymentTermID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.ShipmentTerm)
                .WithMany(st => st.Quotations)
                .HasForeignKey(q => q.ShipmentTermID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Quotation>()
                .HasOne(q => q.QuotationStatus)
                .WithMany(qs => qs.Quotations)
                .HasForeignKey(q => q.QuotationStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Approval History Lookup
            modelBuilder.Entity<ApprovalHistory>()
                .HasOne(ah => ah.ApprovalDecisionStatus)
                .WithMany(ads => ads.ApprovalHistories)
                .HasForeignKey(ah => ah.ApprovalDecisionStatusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Item Category & Type
            modelBuilder.Entity<Item>()
                .HasOne(i => i.ItemCategory)
                .WithMany(ic => ic.Items)
                .HasForeignKey(i => i.ItemCategoryID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
