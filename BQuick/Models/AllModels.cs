using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BQuick.Models
{

    /*public class ReqItem2
    {

        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public int Quantity { get; set; }

        [MaxLength(100)]
        public string UoM { get; set; } = string.Empty;

        [MaxLength(100)]
        public string reasonForReq { get; set; } = string.Empty;

        [MaxLength(100)]
        public string notes { get; set; } = string.Empty;

        public string ImageFileName { get; set; } = string.Empty;

        public byte[]? ImageData { get; set; } // Tipe byte[] akan dipetakan ke VARBINARY(MAX)

        [MaxLength(100)] // Sesuaikan panjang jika perlu
        public string? ImageContentType { get; set; } // Untuk tipe konten gambar

        [MaxLength(100)]
        public string PIC { get; set; } = string.Empty;

        [MaxLength(100)]
        public string status { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
    }

    // --- Entitas Inti & Pengguna ---*/
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Harus selalu menyimpan hash!

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

        // --- Relasi ke RFQ ---
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<RFQ> CreatedRFQs { get; set; }

        [InverseProperty("AssignedToAdminSales")]
        public virtual ICollection<RFQ> AssignedRFQsAsAdmin { get; set; }

        [InverseProperty("SalesManagerAssigner")]
        public virtual ICollection<RFQ> AssignedBySalesManagerRFQs { get; set; }

        [InverseProperty("PersonalResourceEmployee")]
        public virtual ICollection<RFQ> PersonalResourceRFQs { get; set; }

        // --- Relasi ke PurchasingRequest ---
        [InverseProperty("AssignedToPurchasingUser")]
        public virtual ICollection<PurchasingRequest> HandledPurchasingRequests { get; set; }

        [InverseProperty("RequestedByUser")]
        public virtual ICollection<PurchasingRequest> CreatedPurchasingRequests { get; set; }

        // --- Relasi ke SurveyRequest ---
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<SurveyRequest> CreatedSurveyRequests { get; set; }

        [InverseProperty("TechnicalUser")] // Dari SurveyPIC
        public virtual ICollection<SurveyPIC> SurveyAssignments { get; set; }

        // --- Relasi ke MeetingRequest ---
        [InverseProperty("PrimaryPIC_User")]
        public virtual ICollection<MeetingRequest> LedMeetingRequests { get; set; }

        [InverseProperty("CreatedByUser")]
        public virtual ICollection<MeetingRequest> CreatedMeetingRequests { get; set; }

        [InverseProperty("User")] // Dari MeetingPIC
        public virtual ICollection<MeetingPIC> MeetingAssignments { get; set; }

        // --- Relasi ke Quotation ---
        [InverseProperty("PreparedByUser")]
        public virtual ICollection<Quotation> PreparedQuotations { get; set; }

        // FK untuk approver/reviewer final bisa tetap ada untuk kemudahan akses data terkini,
        // sementara ApprovalHistory mencatat seluruh alur.
        [InverseProperty("SalesManagerApprover")]
        public virtual ICollection<Quotation> SMApprovedQuotations { get; set; }

        [InverseProperty("TechnicalManagerApprover")]
        public virtual ICollection<Quotation> TMApprovedQuotations { get; set; }

        [InverseProperty("DirectorApprover")]
        public virtual ICollection<Quotation> DirectorApprovedQuotations { get; set; }

        // --- Relasi ke ApprovalHistory ---
        [InverseProperty("ApproverUser")]
        public virtual ICollection<ApprovalHistory> ApprovalsMade { get; set; }

        // --- Relasi ke Notification ---
        [InverseProperty("RecipientUser")]
        public virtual ICollection<Notification> Notifications { get; set; }

        // --- Relasi ke Attachment & Laporan (sebagai pengunggah/pembuat) ---
        [InverseProperty("UploadedByUser")]
        public virtual ICollection<RFQAttachment> UploadedRFQAttachments { get; set; }

        [InverseProperty("SubmittedByUser")]
        public virtual ICollection<SurveyInstance> SubmittedSurveyInstances { get; set; }

        [InverseProperty("UploadedByUser")]
        public virtual ICollection<SurveyDocumentation> UploadedSurveyDocumentations { get; set; }

        [InverseProperty("GeneratedByUser")]
        public virtual ICollection<SurveyReportInstance> GeneratedSurveyReports { get; set; }

        [InverseProperty("TechManagerReviewer")] // Untuk reviewer akhir di laporan survei
        public virtual ICollection<SurveyReportInstance> TechReviewedSurveyReports { get; set; }

        [InverseProperty("SalesManagerReviewer")] // Untuk reviewer akhir di laporan survei
        public virtual ICollection<SurveyReportInstance> SalesReviewedSurveyReports { get; set; }

        [InverseProperty("GeneratedByUser")]
        public virtual ICollection<MeetingReportInstance> GeneratedMeetingReports { get; set; }

        // Relasi User ke Vendor (User yang membuat data Vendor)
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Vendor> CreatedVendors { get; set; }

        // --- Relasi ke TechnicalCompetency ---
        [InverseProperty("User")]
        public virtual ICollection<TechnicalCompetency> TechnicalCompetencies { get; set; }


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
            SMApprovedQuotations = new HashSet<Quotation>();
            TMApprovedQuotations = new HashSet<Quotation>();
            DirectorApprovedQuotations = new HashSet<Quotation>();
            ApprovalsMade = new HashSet<ApprovalHistory>();
            Notifications = new HashSet<Notification>();
            UploadedRFQAttachments = new HashSet<RFQAttachment>();
            SubmittedSurveyInstances = new HashSet<SurveyInstance>();
            UploadedSurveyDocumentations = new HashSet<SurveyDocumentation>();
            GeneratedSurveyReports = new HashSet<SurveyReportInstance>();
            TechReviewedSurveyReports = new HashSet<SurveyReportInstance>();
            SalesReviewedSurveyReports = new HashSet<SurveyReportInstance>();
            GeneratedMeetingReports = new HashSet<MeetingReportInstance>();
            CreatedVendors = new HashSet<Vendor>();
            TechnicalCompetencies = new HashSet<TechnicalCompetency>();
        }
    }

    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [StringLength(100)]
        public string RoleName { get; set; } // e.g., "Admin Sales", "Sales Manager"

        [InverseProperty("Role")]
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }

    // --- Entitas Terkait Pelanggan ---
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [StringLength(50)]
        public string CustomerCode { get; set; } // e.g., "PEB"

        [Required]
        [StringLength(200)]
        public string CompanyName { get; set; }

        [StringLength(50)]
        public string CustomerType { get; set; } // "Company", "Personal"

        [StringLength(10)]
        public string DefaultCurrency { get; set; } = "IDR";

        public int? DefaultTermsOfPaymentID { get; set; }
        [ForeignKey("DefaultTermsOfPaymentID")]
        public virtual PaymentTerm DefaultTermsOfPayment { get; set; }

        [StringLength(255)]
        public string BillingAddressStreet { get; set; }
        [StringLength(255)]
        public string BillingAddressDetail { get; set; }
        [StringLength(100)]
        public string BillingAddressCity { get; set; }
        [StringLength(100)]
        public string BillingAddressProvince { get; set; }
        [StringLength(100)]
        public string BillingAddressCountry { get; set; }
        [StringLength(20)]
        public string BillingAddressZipCode { get; set; }

        [StringLength(255)]
        public string ShippingAddressStreet { get; set; }
        [StringLength(255)]
        public string ShippingAddressDetail { get; set; }
        [StringLength(100)]
        public string ShippingAddressCity { get; set; }
        [StringLength(100)]
        public string ShippingAddressProvince { get; set; }
        [StringLength(100)]
        public string ShippingAddressCountry { get; set; }
        [StringLength(20)]
        public string ShippingAddressZipCode { get; set; }

        [StringLength(50)]
        public string AccountReceivableCode { get; set; }
        [StringLength(50)]
        public string AccountPayableCode { get; set; }
        [StringLength(50)]
        public string PurchasingLevel { get; set; } // Platinum, Gold, Silver

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerContactPerson> ContactPersons { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<RFQ> RFQs { get; set; }

        public Customer()
        {
            ContactPersons = new HashSet<CustomerContactPerson>();
            RFQs = new HashSet<RFQ>();
        }
    }

    public class CustomerContactPerson
    {
        [Key]
        public int ContactPersonID { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        [InverseProperty("ContactPersons")]
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(200)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        public bool IsPrimary { get; set; } = false;
    }

    // --- Entitas Terkait Item & Vendor ---
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        [Required]
        [StringLength(50)]
        public string ItemCode { get; set; } // Unik, diindeks
        [Required]
        [StringLength(255)]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string ItemImageURL { get; set; }

        public int ItemCategoryID { get; set; }
        [ForeignKey("ItemCategoryID")]
        public virtual ItemCategory ItemCategory { get; set; }

        public int? ItemTypeID { get; set; } // Untuk sub-tipe yang lebih spesifik jika diperlukan
        [ForeignKey("ItemTypeID")]
        public virtual ItemType ItemType { get; set; }

        [StringLength(100)]
        public string Brand { get; set; }
        public string SpecificationDetails { get; set; }
        public decimal? DimensionL { get; set; }
        public decimal? DimensionW { get; set; }
        public decimal? DimensionH { get; set; }
        [StringLength(10)]
        public string DimensionUnit { get; set; } = "cm";
        public decimal? Weight { get; set; }
        [StringLength(10)]
        public string WeightUnit { get; set; } = "kg";
        [StringLength(50)]
        public string ShipmentMethod { get; set; } // Flexible, Can't be shipped by air
        public bool IsTKDN { get; set; } = false;
        [Column(TypeName = "decimal(5, 2)")]
        public decimal? TKDNPercentage { get; set; }
        [StringLength(100)]
        public string TKDNCertificateNumber { get; set; }
        public string TKDNCertificateAttachmentURL { get; set; }

        // Properti spesifik berdasarkan kategori
        [StringLength(50)]
        public string SoftwareVersion { get; set; }
        [StringLength(100)]
        public string LicenseType { get; set; }
        [StringLength(50)]
        public string ItemServiceType { get; set; } // "External" / "Internal"

        public int StockQuantity { get; set; } = 0; // Pertimbangkan apakah ini global atau per vendor
        public bool IsEOS { get; set; } = false; // End of Sale
        public bool IsEOL { get; set; } = false; // End of Life

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("ParentItem")]
        public virtual ICollection<ItemBundle> ParentBundleItems { get; set; }
        [InverseProperty("ChildItem")]
        public virtual ICollection<ItemBundle> ChildBundleItems { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<RFQ_Item> RFQItems { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ItemVendorPricing> VendorPricings { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<QuotationItem> QuotationItems { get; set; }

        public Item()
        {
            ParentBundleItems = new HashSet<ItemBundle>();
            ChildBundleItems = new HashSet<ItemBundle>();
            RFQItems = new HashSet<RFQ_Item>();
            VendorPricings = new HashSet<ItemVendorPricing>();
            QuotationItems = new HashSet<QuotationItem>();
        }
    }

    public class ItemCategory // Tabel Lookup
    {
        [Key]
        public int ItemCategoryID { get; set; }
        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } // Hardware, Software, Service, Other

        [InverseProperty("ItemCategory")]
        public virtual ICollection<Item> Items { get; set; }
        [InverseProperty("ItemCategory")] // Relasi ke ItemType
        public virtual ICollection<ItemType> ItemTypes { get; set; }

        public ItemCategory()
        {
            Items = new HashSet<Item>();
            ItemTypes = new HashSet<ItemType>();
        }
    }

    public class ItemType // Tabel Lookup (opsional, untuk sub-kategori Item)
    {
        [Key]
        public int ItemTypeID { get; set; }
        [Required]
        [StringLength(100)]
        public string ItemTypeName { get; set; } // Misalnya: Laptop, Server (jika ItemCategory = Hardware)

        public int ItemCategoryID { get; set; } // FK ke ItemCategory
        [ForeignKey("ItemCategoryID")]
        [InverseProperty("ItemTypes")]
        public virtual ItemCategory ItemCategory { get; set; }

        [InverseProperty("ItemType")]
        public virtual ICollection<Item> Items { get; set; }
        public ItemType()
        {
            Items = new HashSet<Item>();
        }
    }

    public class ItemBundle
    {
        [Key]
        public int ItemBundleID { get; set; }
        public int ParentItemID { get; set; }
        [ForeignKey("ParentItemID")]
        [InverseProperty("ParentBundleItems")]
        public virtual Item ParentItem { get; set; }

        public int ChildItemID { get; set; }
        [ForeignKey("ChildItemID")]
        [InverseProperty("ChildBundleItems")]
        public virtual Item ChildItem { get; set; }

        public int QuantityInBundle { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PriceInBundle { get; set; } // Harga komponen dalam bundel, jika relevan
    }

    public class Vendor
    {
        [Key]
        public int VendorID { get; set; }
        [Required]
        [StringLength(200)]
        public string VendorName { get; set; }
        [StringLength(50)]
        public string VendorCode { get; set; } // Unik, diindeks
        [StringLength(150)]
        public string ContactPersonName { get; set; }
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        [StringLength(50)]
        public string NPWP { get; set; }

        public int? DefaultPaymentTermID { get; set; }
        [ForeignKey("DefaultPaymentTermID")]
        public virtual PaymentTerm DefaultPaymentTerm { get; set; }

        [StringLength(10)]
        public string DefaultCurrency { get; set; }
        [StringLength(50)]
        public string OfficeType { get; set; } // Pusat, Cabang
        [StringLength(50)]
        public string VendorType { get; set; } // Luar Negeri, Dalam Negeri
        [StringLength(50)]
        public string RiskLevel { get; set; } // High, Medium, Low
        public string CompanyProfileAttachmentURL { get; set; }

        [StringLength(255)]
        public string BillingAddressStreet { get; set; }
        [StringLength(255)]
        public string BillingAddressDetail { get; set; }
        [StringLength(100)]
        public string BillingAddressCity { get; set; }
        [StringLength(100)]
        public string BillingAddressProvince { get; set; }
        [StringLength(100)]
        public string BillingAddressCountry { get; set; }
        [StringLength(20)]
        public string BillingAddressZipCode { get; set; }

        [StringLength(255)]
        public string ShippingAddressStreet { get; set; }
        [StringLength(255)]
        public string ShippingAddressDetail { get; set; }
        [StringLength(100)]
        public string ShippingAddressCity { get; set; }
        [StringLength(100)]
        public string ShippingAddressProvince { get; set; }
        [StringLength(100)]
        public string ShippingAddressCountry { get; set; }
        [StringLength(20)]
        public string ShippingAddressZipCode { get; set; }

        public int? CreatedByUserID { get; set; } // User yang membuat data vendor ini
        [ForeignKey("CreatedByUserID")]
        [InverseProperty("CreatedVendors")]
        public virtual User CreatedByUser { get; set; }

        public DateTime CreatedTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("Vendor")]
        public virtual ICollection<VendorBank> BankAccounts { get; set; }
        [InverseProperty("Vendor")]
        public virtual ICollection<ItemVendorPricing> ItemPricings { get; set; }

        public Vendor()
        {
            BankAccounts = new HashSet<VendorBank>();
            ItemPricings = new HashSet<ItemVendorPricing>();
        }
    }

    public class VendorBank
    {
        [Key]
        public int VendorBankID { get; set; }
        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        [InverseProperty("BankAccounts")]
        public virtual Vendor Vendor { get; set; }

        [Required]
        [StringLength(100)]
        public string BankName { get; set; }
        [StringLength(100)]
        public string BranchName { get; set; }
        [Required]
        [StringLength(150)]
        public string AccountHolderName { get; set; }
        [Required]
        [StringLength(50)]
        public string AccountNumber { get; set; }
        [StringLength(20)]
        public string SwiftCode { get; set; }
    }

    public class ItemVendorPricing
    {
        [Key]
        public int ItemVendorPricingID { get; set; }
        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        [InverseProperty("VendorPricings")]
        public virtual Item Item { get; set; }

        public int VendorID { get; set; }
        [ForeignKey("VendorID")]
        [InverseProperty("ItemPricings")]
        public virtual Vendor Vendor { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [StringLength(10)]
        public string Currency { get; set; }
        public int? LeadTimeValue { get; set; } // Dipisah untuk perhitungan (mis: 4)
        [StringLength(20)]
        public string LeadTimeUnit { get; set; } // Days, Weeks, Months
        public int? WarrantyPeriod { get; set; }
        [StringLength(20)]
        public string WarrantyUnit { get; set; } // "Months", "Years"
        public DateTime PriceValidityStartDate { get; set; }
        public DateTime PriceValidityEndDate { get; set; }
        public int? MinOrderQuantity { get; set; }
        public string Notes { get; set; }
        public int? StockAvailableAtVendor { get; set; } // Stok spesifik di vendor ini

        public DateTime LastUpdatedTimestamp { get; set; } = DateTime.UtcNow;
    }

    // --- Entitas Terkait RFQ ---
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
        [InverseProperty("RFQs")]
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
        public string Resource { get; set; } // Email, Whatsapp, Personal
        public int? PersonalResourceEmployeeID { get; set; }
        [ForeignKey("PersonalResourceEmployeeID")]
        [InverseProperty("PersonalResourceRFQs")]
        public virtual User PersonalResourceEmployee { get; set; }

        public int? RFQCategoryID { get; set; }
        [ForeignKey("RFQCategoryID")]
        public virtual RFQCategory RFQCategory { get; set; } // Project, Middle Project, Non-Project

        public int? RFQOpportunityID { get; set; }
        [ForeignKey("RFQOpportunityID")]
        public virtual RFQOpportunity RFQOpportunity { get; set; } // General, Bundle Installation

        public int RFQStatusID { get; set; }
        [ForeignKey("RFQStatusID")]
        public virtual RFQStatus RFQStatus { get; set; }

        public int CreatedByUserID { get; set; }
        [ForeignKey("CreatedByUserID")]
        [InverseProperty("CreatedRFQs")]
        public virtual User CreatedByUser { get; set; }

        public int? AssignedToAdminSalesID { get; set; }
        [ForeignKey("AssignedToAdminSalesID")]
        [InverseProperty("AssignedRFQsAsAdmin")]
        public virtual User AssignedToAdminSales { get; set; }

        public int? SalesManagerAssignerID { get; set; }
        [ForeignKey("SalesManagerAssignerID")]
        [InverseProperty("AssignedBySalesManagerRFQs")]
        public virtual User SalesManagerAssigner { get; set; }

        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;
        public DateTime LastUpdateTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("RFQ")]
        public virtual ICollection<RFQNote> Notes { get; set; }
        [InverseProperty("RFQ")]
        public virtual ICollection<RFQAttachment> Attachments { get; set; }
        [InverseProperty("RFQ")]
        public virtual ICollection<RFQ_Item> Items { get; set; }
        [InverseProperty("RFQ")]
        public virtual ICollection<PurchasingRequest> PurchasingRequests { get; set; }
        [InverseProperty("RFQ")]
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
        [InverseProperty("RFQ")]
        public virtual ICollection<MeetingRequest> MeetingRequests { get; set; }
        [InverseProperty("RFQ")]
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

    public class RFQCategory // Tabel Lookup
    {
        [Key]
        public int RFQCategoryID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Project, Middle Project, Non-Project
        [InverseProperty("RFQCategory")]
        public virtual ICollection<RFQ> RFQs { get; set; } = new HashSet<RFQ>();
    }

    public class RFQOpportunity // Tabel Lookup
    {
        [Key]
        public int RFQOpportunityID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // General, Bundle Installation, Professional Service
        [InverseProperty("RFQOpportunity")]
        public virtual ICollection<RFQ> RFQs { get; set; } = new HashSet<RFQ>();
    }

    public class RFQStatus // Tabel Lookup
    {
        [Key]
        public int RFQStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Waiting Assign, Open, Waiting Purchasing, etc.
        [InverseProperty("RFQStatus")]
        public virtual ICollection<RFQ> RFQs { get; set; } = new HashSet<RFQ>();
    }

    public class RFQNote
    {
        [Key]
        public int RFQNoteID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("Notes")]
        public virtual RFQ RFQ { get; set; }

        [StringLength(255)]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? BudgetTarget { get; set; }
        [StringLength(100)]
        public string LeadTimeTarget { get; set; }
    }

    public class RFQAttachment
    {
        [Key]
        public int RFQAttachmentID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("Attachments")]
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(255)]
        public string FileName { get; set; }
        [Required]
        public string FileURL { get; set; }
        public DateTime UploadTimestamp { get; set; } = DateTime.UtcNow;

        public int? UploadedByUserID { get; set; } // User yang mengunggah
        [ForeignKey("UploadedByUserID")]
        [InverseProperty("UploadedRFQAttachments")]
        public virtual User UploadedByUser { get; set; }
    }

    public class RFQ_Item
    {
        [Key]
        public int RFQ_ItemID { get; set; }

        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("Items")]
        public virtual RFQ RFQ { get; set; }

        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        [InverseProperty("RFQItems")]
        public virtual Item Item { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TargetUnitPrice { get; set; }
        public string Notes { get; set; }
        public string Details { get; set; }    // Detail tambahan dari sales untuk item ini di RFQ
        [StringLength(100)]
        public string SalesWarranty { get; set; } // Garansi yang ditawarkan sales (bisa beda dari vendor)

        public int? ChosenVendorID { get; set; }    // Vendor yang dipilih sales untuk item ini (jika ada preferensi awal)
        [ForeignKey("ChosenVendorID")]
        public virtual Vendor ChosenVendor { get; set; }

        // Untuk melacak kembali ke request purchasing jika item ini berasal dari sana
        public int? OriginatingPurchasingRequestID { get; set; }
        [ForeignKey("OriginatingPurchasingRequestID")]
        [InverseProperty("ResultingRFQItems")]
        public virtual PurchasingRequest OriginatingPurchasingRequest { get; set; }
    }

    // --- Entitas Terkait Purchasing ---
    public class PurchasingRequest
    {
        [Key]
        public int PurchasingRequestID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("PurchasingRequests")]
        public virtual RFQ RFQ { get; set; }

        public int? ItemID_IfExists { get; set; }    // ItemID jika item sudah ada di database
        [ForeignKey("ItemID_IfExists")]
        public virtual Item ItemIfExists { get; set; }

        [StringLength(255)]
        public string RequestedItemName { get; set; }    // Nama item jika belum ada di DB
        public string RequestedItemDescription { get; set; }    // Deskripsi item jika belum ada di DB
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }
        [StringLength(100)]
        public string ReasonForRequest { get; set; } // Not yet in Database, Leadtime not suitable, Out of Stock, Invalid Price, etc.
        public string SalesNotes { get; set; } // Catatan dari Sales untuk Purchasing
        public string SalesAttachmentURL { get; set; } // Lampiran dari Sales untuk Purchasing

        public int? AssignedToPurchasingUserID { get; set; }    // User Purchasing yang menangani
        [ForeignKey("AssignedToPurchasingUserID")]
        [InverseProperty("HandledPurchasingRequests")]
        public virtual User AssignedToPurchasingUser { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; } // Batas waktu untuk Purchasing mendapatkan harga

        public int PurchasingStatusID { get; set; }
        [ForeignKey("PurchasingStatusID")]
        public virtual PurchasingStatus PurchasingStatus { get; set; } // Status proses di Purchasing

        public int RequestedByUserID { get; set; }    // User Sales yang membuat request ini
        [ForeignKey("RequestedByUserID")]
        [InverseProperty("CreatedPurchasingRequests")]
        public virtual User RequestedByUser { get; set; }

        [InverseProperty("OriginatingPurchasingRequest")]
        public virtual ICollection<RFQ_Item> ResultingRFQItems { get; set; } = new HashSet<RFQ_Item>();
    }

    public class PurchasingStatus // Tabel Lookup
    {
        [Key]
        public int PurchasingStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Open, On Progress, 1st Follow Up, Completed, Escalation
        [InverseProperty("PurchasingStatus")]
        public virtual ICollection<PurchasingRequest> PurchasingRequests { get; set; } = new HashSet<PurchasingRequest>();
    }

    // --- Entitas Terkait Survei ---
    public class SurveyCategory // Kategori atau Kompetensi Survei
    {
        [Key]
        public int SurveyCategoryID { get; set; }
        [Required]
        [StringLength(150)]
        public string CategoryName { get; set; } // e.g., Security Access, Network Cabling, CCTV System
        [InverseProperty("SurveyCategory")]
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; }
        [InverseProperty("SurveyCategory")]
        public virtual ICollection<TechnicalCompetency> TechnicalCompetencies { get; set; }

        public SurveyCategory()
        {
            SurveyRequests = new HashSet<SurveyRequest>();
            TechnicalCompetencies = new HashSet<TechnicalCompetency>();
        }
    }

    // Tabel Join untuk User (Teknisi) dan SurveyCategory (Kompetensi)
    public class TechnicalCompetency
    {
        [Key] // EF Core akan mengatur composite key
        public int UserID { get; set; } // PK, FK
        [ForeignKey("UserID")]
        [InverseProperty("TechnicalCompetencies")]
        public virtual User User { get; set; }

        [Key] // EF Core akan mengatur composite key
        public int SurveyCategoryID { get; set; } // PK, FK
        [ForeignKey("SurveyCategoryID")]
        [InverseProperty("TechnicalCompetencies")]
        public virtual SurveyCategory SurveyCategory { get; set; }
    }

    public class SurveyRequest
    {
        [Key]
        public int SurveyRequestID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("SurveyRequests")]
        public virtual RFQ RFQ { get; set; }

        [Required]
        [StringLength(50)]
        public string SurveyCode { get; set; } // Unik, diindeks
        [StringLength(255)]
        public string SurveyName { get; set; }

        public int SurveyCategoryID { get; set; }
        [ForeignKey("SurveyCategoryID")]
        [InverseProperty("SurveyRequests")]
        public virtual SurveyCategory SurveyCategory { get; set; }

        [StringLength(150)]
        public string CustomerPICName { get; set; } // Nama PIC Customer di lokasi survei
        public DateTime RequestedDateTime { get; set; } // Tanggal & Waktu survei yang diminta
        public string LocationDetails { get; set; } // Detail lokasi survei
        public string SalesNotesInternal { get; set; } // Catatan internal dari Sales untuk tim teknis

        public int SurveyStatusID { get; set; }
        [ForeignKey("SurveyStatusID")]
        public virtual SurveyStatus SurveyStatus { get; set; }

        public int CreatedByUserID { get; set; }    // User Sales yang membuat request survei
        [ForeignKey("CreatedByUserID")]
        [InverseProperty("CreatedSurveyRequests")]
        public virtual User CreatedByUser { get; set; }

        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("SurveyRequest")]
        public virtual ICollection<SurveyPIC> AssignedPICs { get; set; } // Tim teknis yang ditugaskan
        [InverseProperty("SurveyRequest")]
        public virtual ICollection<SurveyInstance> SurveyInstances { get; set; } // Hasil pelaksanaan survei

        public SurveyRequest()
        {
            AssignedPICs = new HashSet<SurveyPIC>();
            SurveyInstances = new HashSet<SurveyInstance>();
        }
    }

    public class SurveyStatus // Tabel Lookup
    {
        [Key]
        public int SurveyStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Not Yet, Waiting Tech Manager Approval, Waiting PIC Approval, Approved, On Progress, Report Submitted, etc.
        [InverseProperty("SurveyStatus")]
        public virtual ICollection<SurveyRequest> SurveyRequests { get; set; } = new HashSet<SurveyRequest>();
    }

    public class SurveyPIC // Teknisi yang ditugaskan untuk survei
    {
        [Key]
        public int SurveyPIC_ID { get; set; }
        public int SurveyRequestID { get; set; }
        [ForeignKey("SurveyRequestID")]
        [InverseProperty("AssignedPICs")]
        public virtual SurveyRequest SurveyRequest { get; set; }

        public int TechnicalUserID { get; set; }    // User teknisi
        [ForeignKey("TechnicalUserID")]
        [InverseProperty("SurveyAssignments")]
        public virtual User TechnicalUser { get; set; }

        public int PICApprovalStatusID { get; set; } // Status persetujuan dari teknisi
        [ForeignKey("PICApprovalStatusID")]
        public virtual PICApprovalStatus PICApprovalStatus { get; set; }
    }

    public class PICApprovalStatus // Tabel Lookup untuk status persetujuan PIC (Teknisi/Sales Meeting)
    {
        [Key]
        public int PICApprovalStatusID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } // Pending, Accepted, Rejected
        [InverseProperty("PICApprovalStatus")]
        public virtual ICollection<SurveyPIC> SurveyPICs { get; set; } = new HashSet<SurveyPIC>();
        [InverseProperty("PICApprovalStatus")]
        public virtual ICollection<MeetingPIC> MeetingPICs { get; set; } = new HashSet<MeetingPIC>();
    }

    public class SurveyFormMaster // Master template untuk form survei
    {
        [Key]
        public int SurveyFormID { get; set; }
        [Required]
        [StringLength(150)]
        public string FormName { get; set; } // e.g., Access Control Form, Network Assessment Form
        public string FormTemplateDefinition { get; set; } // JSON/XML struktur form atau path ke template
        public bool IsActive { get; set; } = true;
        [InverseProperty("SurveyForm")]
        public virtual ICollection<SurveyInstance> SurveyInstances { get; set; }
        public SurveyFormMaster()
        {
            SurveyInstances = new HashSet<SurveyInstance>();
        }
    }

    public class SurveyInstance // Instance spesifik dari pelaksanaan survei
    {
        [Key]
        public int SurveyInstanceID { get; set; }
        public int SurveyRequestID { get; set; }
        [ForeignKey("SurveyRequestID")]
        [InverseProperty("SurveyInstances")]
        public virtual SurveyRequest SurveyRequest { get; set; }

        public int SurveyFormID { get; set; }    // Form yang digunakan
        [ForeignKey("SurveyFormID")]
        [InverseProperty("SurveyInstances")]
        public virtual SurveyFormMaster SurveyForm { get; set; }

        public DateTime? ActualSurveyStartTime { get; set; }
        public DateTime? ActualSurveyEndTime { get; set; }
        public string FilledFormData { get; set; } // Data hasil isian form (JSON/XML)

        public int SubmittedByUserID { get; set; }    // Teknisi yang submit hasil survei
        [ForeignKey("SubmittedByUserID")]
        [InverseProperty("SubmittedSurveyInstances")]
        public virtual User SubmittedByUser { get; set; }

        [StringLength(50)]
        public string SubmissionStatus { get; set; } // e.g., Draft, Submitted
        public DateTime SubmissionTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("SurveyInstance")]
        public virtual ICollection<SurveyDocumentation> Documentations { get; set; } // Foto, denah, dll.
        [InverseProperty("SurveyInstance")]
        public virtual ICollection<SurveyReportInstance> Reports { get; set; } // Laporan yang dihasilkan
        public SurveyInstance()
        {
            Documentations = new HashSet<SurveyDocumentation>();
            Reports = new HashSet<SurveyReportInstance>();
        }
    }

    public class SurveyDocumentation // Dokumentasi pendukung survei
    {
        [Key]
        public int SurveyDocumentationID { get; set; }
        public int SurveyInstanceID { get; set; }
        [ForeignKey("SurveyInstanceID")]
        [InverseProperty("Documentations")]
        public virtual SurveyInstance SurveyInstance { get; set; }
        [Required, StringLength(255)]
        public string FileName { get; set; }
        [Required]
        public string FileURL { get; set; }
        public int UploadedByUserID { get; set; }
        [ForeignKey("UploadedByUserID")]
        [InverseProperty("UploadedSurveyDocumentations")]
        public virtual User UploadedByUser { get; set; }
        public DateTime UploadTimestamp { get; set; } = DateTime.UtcNow;
    }

    public class ReportMaster // Master template untuk berbagai jenis laporan
    {
        [Key]
        public int ReportMasterID { get; set; }
        [Required]
        [StringLength(150)]
        public string ReportName { get; set; } // e.g., MLA (Material List Approval), BoQ, MoM (Minute of Meeting)
        public string ReportTemplateDefinition { get; set; } // Struktur atau path ke template laporan
        public bool IsActive { get; set; } = true;
        [InverseProperty("ReportMaster")]
        public virtual ICollection<SurveyReportInstance> SurveyReportInstances { get; set; }
        [InverseProperty("ReportMaster")]
        public virtual ICollection<MeetingReportInstance> MeetingReportInstances { get; set; }

        public ReportMaster()
        {
            SurveyReportInstances = new HashSet<SurveyReportInstance>();
            MeetingReportInstances = new HashSet<MeetingReportInstance>();
        }
    }

    public class SurveyReportInstance // Instance laporan hasil survei
    {
        [Key]
        public int SurveyReportInstanceID { get; set; }
        public int SurveyInstanceID { get; set; }
        [ForeignKey("SurveyInstanceID")]
        [InverseProperty("Reports")]
        public virtual SurveyInstance SurveyInstance { get; set; }

        public int ReportMasterID { get; set; }    // Jenis laporan yang digunakan
        [ForeignKey("ReportMasterID")]
        [InverseProperty("SurveyReportInstances")]
        public virtual ReportMaster ReportMaster { get; set; }

        public string ReportContent { get; set; } // Konten laporan (JSON/XML/HTML atau path)
        public int GeneratedByUserID { get; set; }    // User yang generate laporan
        [ForeignKey("GeneratedByUserID")]
        [InverseProperty("GeneratedSurveyReports")]
        public virtual User GeneratedByUser { get; set; }
        public DateTime GeneratedTimestamp { get; set; } = DateTime.UtcNow;

        public int ReportStatusID { get; set; } // Status laporan survei
        [ForeignKey("ReportStatusID")]
        public virtual ReportStatus ReportStatus { get; set; }

        // Reviewer akhir dapat disimpan di sini untuk akses cepat, ApprovalHistory untuk audit lengkap
        public int? TechManagerReviewerID { get; set; }
        [ForeignKey("TechManagerReviewerID")]
        [InverseProperty("TechReviewedSurveyReports")]
        public virtual User TechManagerReviewer { get; set; }

        public int? SalesManagerReviewerID { get; set; }
        [ForeignKey("SalesManagerReviewerID")]
        [InverseProperty("SalesReviewedSurveyReports")]
        public virtual User SalesManagerReviewer { get; set; }

        [InverseProperty("SurveyReportInstance")]
        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; } = new HashSet<ApprovalHistory>();
    }

    public class ReportStatus // Tabel Lookup untuk status laporan (Survey & Meeting)
    {
        [Key]
        public int ReportStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Draft, SubmittedForReview, Approved, Rejected
        [InverseProperty("ReportStatus")]
        public virtual ICollection<SurveyReportInstance> SurveyReportInstances { get; set; } = new HashSet<SurveyReportInstance>();
        [InverseProperty("ReportStatus")]
        public virtual ICollection<MeetingReportInstance> MeetingReportInstances { get; set; } = new HashSet<MeetingReportInstance>();
    }

    // --- Entitas Terkait Meeting ---
    public class MeetingRequest
    {
        [Key]
        public int MeetingRequestID { get; set; }
        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("MeetingRequests")]
        public virtual RFQ RFQ { get; set; }
        [Required]
        [StringLength(50)]
        public string MeetingCode { get; set; } // Unik, diindeks
        [StringLength(255)]
        public string MeetingName { get; set; }
        public int PrimaryPIC_UserID { get; set; }    // PIC Utama dari tim Sales
        [ForeignKey("PrimaryPIC_UserID")]
        [InverseProperty("LedMeetingRequests")]
        public virtual User PrimaryPIC_User { get; set; }
        public DateTime RequestedDateTime { get; set; }
        public string LocationDetails { get; set; } // Offline (Alamat) / Online (Link Meeting)
        public string NotesInternal { get; set; } // Catatan internal

        public int MeetingStatusID { get; set; }
        [ForeignKey("MeetingStatusID")]
        public virtual MeetingStatus MeetingStatus { get; set; }

        public int CreatedByUserID { get; set; }    // User yang membuat request meeting
        [ForeignKey("CreatedByUserID")]
        [InverseProperty("CreatedMeetingRequests")]
        public virtual User CreatedByUser { get; set; }
        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("MeetingRequest")]
        public virtual ICollection<MeetingPIC> AssignedPICs { get; set; } // Peserta meeting dari internal
        [InverseProperty("MeetingRequest")]
        public virtual ICollection<MeetingReportInstance> Reports { get; set; }    // Laporan hasil meeting (MoM)

        public MeetingRequest()
        {
            AssignedPICs = new HashSet<MeetingPIC>();
            Reports = new HashSet<MeetingReportInstance>();
        }
    }

    public class MeetingStatus // Tabel Lookup
    {
        [Key]
        public int MeetingStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Scheduled, Waiting PIC Approval, On Progress, Completed, Cancelled
        [InverseProperty("MeetingStatus")]
        public virtual ICollection<MeetingRequest> MeetingRequests { get; set; } = new HashSet<MeetingRequest>();
    }

    public class MeetingPIC // Peserta internal meeting
    {
        [Key]
        public int MeetingPIC_ID { get; set; }
        public int MeetingRequestID { get; set; }
        [ForeignKey("MeetingRequestID")]
        [InverseProperty("AssignedPICs")]
        public virtual MeetingRequest MeetingRequest { get; set; }
        public int UserID { get; set; }    // User peserta
        [ForeignKey("UserID")]
        [InverseProperty("MeetingAssignments")]
        public virtual User User { get; set; }

        public int PICApprovalStatusID { get; set; } // Status konfirmasi kehadiran dari peserta
        [ForeignKey("PICApprovalStatusID")]
        [InverseProperty("MeetingPICs")]
        public virtual PICApprovalStatus PICApprovalStatus { get; set; }
    }

    public class MeetingReportInstance // MoM (Minute of Meeting)
    {
        [Key]
        public int MeetingReportInstanceID { get; set; }
        public int MeetingRequestID { get; set; }
        [ForeignKey("MeetingRequestID")]
        [InverseProperty("Reports")]
        public virtual MeetingRequest MeetingRequest { get; set; }
        public int ReportMasterID { get; set; } // Jenis laporan (MoM dari ReportMaster)
        [ForeignKey("ReportMasterID")]
        [InverseProperty("MeetingReportInstances")]
        public virtual ReportMaster ReportMaster { get; set; }
        public string ReportContent { get; set; } // Konten MoM
        public int GeneratedByUserID { get; set; }    // User yang membuat MoM
        [ForeignKey("GeneratedByUserID")]
        [InverseProperty("GeneratedMeetingReports")]
        public virtual User GeneratedByUser { get; set; }
        public DateTime GeneratedTimestamp { get; set; } = DateTime.UtcNow;

        public int ReportStatusID { get; set; } // Status MoM
        [ForeignKey("ReportStatusID")]
        [InverseProperty("MeetingReportInstances")]
        public virtual ReportStatus ReportStatus { get; set; }

        [InverseProperty("MeetingReportInstance")]
        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; } = new HashSet<ApprovalHistory>();
    }

    // --- Entitas Terkait Quotation ---
    public class Quotation
    {
        [Key]
        public int QuotationID { get; set; }

        [Required]
        [StringLength(50)]
        public string QuotationCode { get; set; } // Unik, diindeks

        public int RFQID { get; set; }
        [ForeignKey("RFQID")]
        [InverseProperty("Quotations")]
        public virtual RFQ RFQ { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? ExpiryDate { get; set; }
        public string DeliveryInfo { get; set; }
        [StringLength(10)]
        public string Currency { get; set; } = "IDR";
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? ExchangeRate { get; set; } // Kurs jika mata uang bukan IDR

        public int PaymentTermID { get; set; }
        [ForeignKey("PaymentTermID")]
        public virtual PaymentTerm PaymentTerm { get; set; }

        public int ShipmentTermID { get; set; }
        [ForeignKey("ShipmentTermID")]
        public virtual ShipmentTerm ShipmentTerm { get; set; }

        public int PreparedByUserID { get; set; }
        [ForeignKey("PreparedByUserID")]
        [InverseProperty("PreparedQuotations")]
        public virtual User PreparedByUser { get; set; }

        // Kolom biaya detail
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalUnitCost_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPPN_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalEndorsement_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalFreight_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverallTotalCost_Internal { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalQuoteAmount_Customer { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal OverallMarginAmount_Internal { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal OverallMarginPercentage_Internal { get; set; }

        public string RemarkToCustomer { get; set; }
        public string InternalNotes { get; set; }
        public string FooterText { get; set; }

        public int QuotationStatusID { get; set; }
        [ForeignKey("QuotationStatusID")]
        public virtual QuotationStatus QuotationStatus { get; set; }

        public int? SplitParentQuotationID { get; set; }    // Jika quotation ini adalah hasil split
        [ForeignKey("SplitParentQuotationID")]
        [InverseProperty("SplitChildQuotations")]
        public virtual Quotation SplitParentQuotation { get; set; }

        [InverseProperty("SplitParentQuotation")]
        public virtual ICollection<Quotation> SplitChildQuotations { get; set; }

        // FK Approver spesifik (untuk approver final atau akses cepat)
        public int? SalesManagerApproverID { get; set; }
        [ForeignKey("SalesManagerApproverID")]
        [InverseProperty("SMApprovedQuotations")]
        public virtual User SalesManagerApprover { get; set; }
        public int? TechnicalManagerApproverID { get; set; }
        [ForeignKey("TechnicalManagerApproverID")]
        [InverseProperty("TMApprovedQuotations")]
        public virtual User TechnicalManagerApprover { get; set; }
        public int? DirectorApproverID { get; set; }
        [ForeignKey("DirectorApproverID")]
        [InverseProperty("DirectorApprovedQuotations")]
        public virtual User DirectorApprover { get; set; }

        public DateTime? SentToCustomerTimestamp { get; set; }
        public string SentToCustomerProofURL { get; set; } // URL bukti pengiriman

        public DateTime LastModifiedTimestamp { get; set; } = DateTime.UtcNow;

        [InverseProperty("Quotation")]
        public virtual ICollection<QuotationItem> Items { get; set; }
        [InverseProperty("Quotation")]
        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; }

        public Quotation()
        {
            Items = new HashSet<QuotationItem>();
            SplitChildQuotations = new HashSet<Quotation>();
            ApprovalHistories = new HashSet<ApprovalHistory>();
        }
    }

    public class PaymentTerm // Tabel Lookup
    {
        [Key]
        public int PaymentTermID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // 30 days, Cash In Advance, etc.
        public bool IsActive { get; set; } = true;
        [InverseProperty("DefaultTermsOfPayment")]
        public virtual ICollection<Customer> CustomersAsDefault { get; set; } = new HashSet<Customer>();
        [InverseProperty("DefaultPaymentTerm")]
        public virtual ICollection<Vendor> VendorsAsDefault { get; set; } = new HashSet<Vendor>();
        [InverseProperty("PaymentTerm")]
        public virtual ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }

    public class ShipmentTerm // Tabel Lookup
    {
        [Key]
        public int ShipmentTermID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // DDP PEB, FOB Batam, etc.
        public bool IsActive { get; set; } = true;
        [InverseProperty("ShipmentTerm")]
        public virtual ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }

    public class QuotationStatus // Tabel Lookup
    {
        [Key]
        public int QuotationStatusID { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } // Draft, Waiting SM Approval, Approved by Director, Sent to Customer
        [InverseProperty("QuotationStatus")]
        public virtual ICollection<Quotation> Quotations { get; set; } = new HashSet<Quotation>();
    }

    public class QuotationItem
    {
        [Key]
        public int QuotationItemID { get; set; }
        public int QuotationID { get; set; }
        [ForeignKey("QuotationID")]
        [InverseProperty("Items")]
        public virtual Quotation Quotation { get; set; }

        public int ItemID { get; set; }
        [ForeignKey("ItemID")]
        [InverseProperty("QuotationItems")]
        public virtual Item Item { get; set; }

        public int? RFQ_ItemID { get; set; }    // Link ke item RFQ asal
        [ForeignKey("RFQ_ItemID")]
        public virtual RFQ_Item RFQ_Item { get; set; }

        public string DescriptionOverride { get; set; } // Jika deskripsi di quotation beda dari master item
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [StringLength(20)]
        public string UoM { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost_Internal { get; set; }

        // PPN bisa berupa persentase dari UnitCost atau nilai tetap
        [Column(TypeName = "decimal(5, 4)")] // Untuk persentase (misal 0.11 untuk 11%)
        public decimal? PPN_Percentage { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? PPN_FixedAmount { get; set; } // Jika PPN adalah nilai tetap per unit

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Endorsement_Amount { get; set; } // Biaya endorsement per unit
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Freight_AmountPerUnit { get; set; } // Biaya pengiriman per unit

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalCostPerUnit_Internal { get; set; } // Kalkulasi: UnitCost + PPN_calc + Endorsement + Freight
        [Column(TypeName = "decimal(18, 2)")]
        public decimal QuotePricePerUnit_Customer { get; set; } // Harga jual ke customer per unit
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalQuotePrice_Customer { get; set; } // Kalkulasi: QuotePricePerUnit * Quantity
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MarginAmount_Internal { get; set; } // Kalkulasi: QuotePricePerUnit_Customer - TotalCostPerUnit_Internal
        [Column(TypeName = "decimal(18, 4)")]
        public decimal MarginPercentage_Internal { get; set; } // Kalkulasi

        [StringLength(100)]
        public string SalesWarranty { get; set; } // Garansi yang ditawarkan di quotation
        public bool DisplayWithDetailInternal { get; set; } // Apakah detail internal (cost, margin) ditampilkan di versi internal
        public int DisplaySequence { get; set; } // Urutan tampilan item di quotation
    }

    // --- Entitas Generik untuk Persetujuan & Notifikasi ---
    public class ApprovalHistory // Mencatat semua histori approval
    {
        [Key]
        public int ApprovalHistoryID { get; set; }

        [Required]
        [StringLength(100)]
        public string EntityType { get; set; } // "Quotation", "SurveyReportInstance", "MeetingReportInstance", "Customer" etc.

        [Required]
        public int EntityID { get; set; } // FK ke entitas terkait (QuotationID, SurveyReportInstanceID, dll.)

        public int ApproverUserID { get; set; }
        [ForeignKey("ApproverUserID")]
        [InverseProperty("ApprovalsMade")]
        public virtual User ApproverUser { get; set; }

        [StringLength(100)]
        public string ApproverRoleAtTime { get; set; } // Peran approver saat itu

        public int ApprovalDecisionStatusID { get; set; } // Keputusan approval
        [ForeignKey("ApprovalDecisionStatusID")]
        public virtual ApprovalDecisionStatus ApprovalDecisionStatus { get; set; }

        public string Remarks { get; set; } // Catatan dari approver
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public int StepOrder { get; set; } // Urutan langkah approval jika multi-langkah

        // Navigasi balik ke entitas spesifik (opsional, tergantung kebutuhan query)
        [InverseProperty("ApprovalHistories")]
        public virtual Quotation Quotation { get; set; }
        [InverseProperty("ApprovalHistories")]
        public virtual SurveyReportInstance SurveyReportInstance { get; set; }
        [InverseProperty("ApprovalHistories")]
        public virtual MeetingReportInstance MeetingReportInstance { get; set; }
        // Tambahkan entitas lain yang memerlukan approval jika perlu
    }

    public class ApprovalDecisionStatus // Tabel Lookup untuk keputusan approval
    {
        [Key]
        public int ApprovalDecisionStatusID { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } // Approved, Rejected, Requested Revision, Pending, etc.
        [InverseProperty("ApprovalDecisionStatus")]
        public virtual ICollection<ApprovalHistory> ApprovalHistories { get; set; } = new HashSet<ApprovalHistory>();
    }

    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public int RecipientUserID { get; set; }
        [ForeignKey("RecipientUserID")]
        [InverseProperty("Notifications")]
        public virtual User RecipientUser { get; set; }
        [Required]
        public string Message { get; set; }
        [StringLength(100)]
        public string NotificationType { get; set; } // NewTask, ApprovalRequest, Information, Reminder
        [StringLength(100)]
        public string RelatedEntityType { get; set; } // RFQ, Quotation, SurveyRequest, etc.
        public int? RelatedEntityID { get; set; } // ID dari entitas terkait
        public string NavigationURL { get; set; } // URL untuk navigasi langsung ke item terkait
        public bool IsRead { get; set; } = false;
        public DateTime CreationTimestamp { get; set; } = DateTime.UtcNow;
    }

    public class Setting // Untuk konfigurasi aplikasi
    {
        [Key]
        public int SettingID { get; set; }
        [Required, StringLength(100)]
        public string SettingGroup { get; set; } // e.g., RFQOptions, EmailConfig, ApprovalFlow
        [Required, StringLength(100)]
        public string SettingKey { get; set; } // e.g., DefaultDueDateDays, SMTPHost
        public string SettingValue { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}