// File: BQuick/Models/ViewModels/RfqCreateFullViewModel.cs
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BQuick.Models
{
    // --- Sub-ViewModel untuk bagian "Notes" ---
    public class RfqCreateNoteItemViewModel
    {
        [StringLength(255)]
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Kuantitas harus lebih besar dari 0")]
        public decimal Quantity { get; set; } = 1;

        [StringLength(20)]
        public string UoM { get; set; } = "Unit";

        [DataType(DataType.Currency)]
        public decimal? BudgetTarget { get; set; }

        [StringLength(100)]
        public string LeadTimeTarget { get; set; }
    }

    // --- Sub-ViewModel untuk bagian "Item List" (RFQ_Item) ---
    public class RfqCreateRfqItemViewModel
    {
        public int ItemID { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Kuantitas harus lebih besar dari 0.")]
        public decimal Quantity { get; set; } = 1;

        public string ItemDescription { get; set; }

        [StringLength(20)]
        public string UoM { get; set; } = "Unit";

        [DataType(DataType.Currency)]
        public decimal? TargetUnitPrice { get; set; }

        public string Notes { get; set; }

        public string Details { get; set; }

        [StringLength(100)]
        public string? SalesWarranty { get; set; }
    }

    // --- Sub-ViewModel untuk "Request Item to Purchasing" ---
    public class RfqCreatePurchasingRequestItemViewModel
    {
        public int? ItemID_IfExists { get; set; }

        [StringLength(255)]
        public string? RequestedItemName { get; set; }

        public string? RequestedItemDescription { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Kuantitas harus lebih besar dari 0.")]
        public decimal Quantity { get; set; } = 1;

        [StringLength(20)]
        public string UoM { get; set; } = "Unit";

        [StringLength(100)]
        public string ReasonForRequest { get; set; }

        public string SalesNotes { get; set; }

        public int? AssignedToPurchasingUserID { get; set; }
    }

    // --- Sub-ViewModel untuk "Survey List" ---
    public class RfqCreateSurveyRequestItemViewModel
    {
        public List<int> SurveyCategoryIDs { get; set; }

        [StringLength(255)]
        public string SurveyName { get; set; }

        [StringLength(150)]
        public string CustomerPICName { get; set; }

        public List<int> TechnicalUserIDs { get; set; }

        [Display(Name = "Waktu Mulai Survey")]
        public DateTime? RequestStartTime { get; set; }

        [Display(Name = "Waktu Selesai Survey")]
        public DateTime? RequestEndTime { get; set; }

        public string LocationDetails { get; set; }

        public string SalesNotesInternal { get; set; }
        public string SurveyStatus { get; set; } = "Open"; // Beri nilai default "Open"

        public RfqCreateSurveyRequestItemViewModel()
        {
            SurveyCategoryIDs = new List<int>();
            TechnicalUserIDs = new List<int>();
        }
    }

    public class RfqCreateMeetingItemViewModel
    {
        [StringLength(255)]
        public string MeetingName { get; set; }
        public DateTime? MeetingStartTime { get; set; }
        public DateTime? MeetingEndTime { get; set; }
        public string LocationDetails { get; set; }
        public string NotesInternal { get; set; }
        public List<int> AssignedPICs { get; set; } = new List<int>();
        public int MeetingStatusID { get; set; }
        public string MeetingStatusName { get; set; }
    }


    // --- ViewModel Utama untuk Halaman Create RFQ ---
    public class RfqCreateFullViewModel
    {
        public int? RFQID_FromEdit { get; set; } // TAMBAHKAN BARIS INI
        // --- Properti untuk RFQ Header ---
        [StringLength(50)]
        public string RFQCode { get; set; }

        [Required(ErrorMessage = "Nama RFQ harus diisi.")]
        [StringLength(255)]
        public string RFQName { get; set; }

        [Required(ErrorMessage = "Customer (Company Name) harus dipilih.")]
        public int CustomerID { get; set; }

        public int? ContactPersonID { get; set; }

        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(14);

        // --- PROPERTI YANG DITAMBAHKAN ---
        [DataType(DataType.Currency)]
        public decimal? OverallBudget { get; set; }

        [StringLength(100)]
        public string? OverallLeadTime { get; set; }
        // --- AKHIR PROPERTI YANG DITAMBAHKAN ---

        [StringLength(50)]
        public string Resource { get; set; }

        public int? PersonalResourceEmployeeID { get; set; }

        public int? RFQCategoryID { get; set; }

        public int? RFQOpportunityID { get; set; }

        [Display(Name = "End User")]
        public int? EndUserContactPersonID { get; set; } // Untuk menampung ID End User yang dipilih
        public SelectList? EndUserContactPersonList { get; set; } // Untuk daftar pilihan End User

        public List<IFormFile>? AttachmentFiles { get; set; }

        // --- Koleksi untuk setiap bagian form ---
        public List<RfqCreateNoteItemViewModel> NotesSectionItems { get; set; }
        public List<RfqCreateRfqItemViewModel> ItemListSectionItems { get; set; }
        public List<RfqCreatePurchasingRequestItemViewModel> PurchasingRequestSectionItems { get; set; }
        public List<RfqCreateSurveyRequestItemViewModel> SurveySectionItems { get; set; }
        public List<RfqCreateMeetingItemViewModel> MeetingSectionItems { get; set; } = new List<RfqCreateMeetingItemViewModel>();

        // --- Properti untuk mengisi Dropdown Lists ---
        public SelectList? CustomerList { get; set; }
        public SelectList? ContactPersonList { get; set; }
        public SelectList? UserList { get; set; }
        public SelectList? RFQCategoryList { get; set; }
        public SelectList? RFQOpportunityList { get; set; }
        public SelectList? ItemMasterList { get; set; }
        public SelectList? SurveyCategoryList { get; set; }
        public SelectList? PurchasingUserList { get; set; }
        public SelectList? SurveyUserList { get; set; }

        public RfqCreateFullViewModel()
        {
            NotesSectionItems = new List<RfqCreateNoteItemViewModel> { new RfqCreateNoteItemViewModel() };
            ItemListSectionItems = new List<RfqCreateRfqItemViewModel> { new RfqCreateRfqItemViewModel() };
            PurchasingRequestSectionItems = new List<RfqCreatePurchasingRequestItemViewModel> { new RfqCreatePurchasingRequestItemViewModel() };
            SurveySectionItems = new List<RfqCreateSurveyRequestItemViewModel>();


            // Inisialisasi EndUserContactPersonList agar tidak null saat view pertama kali dimuat
            EndUserContactPersonList = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
            AttachmentFiles = new List<IFormFile>();
        }
    }
}
