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
        [Required(ErrorMessage = "Item harus dipilih.")]
        public int ItemID { get; set; }

        [Required(ErrorMessage = "Kuantitas harus diisi.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Kuantitas harus lebih besar dari 0.")]
        public decimal Quantity { get; set; } = 1;

        [StringLength(20)]
        public string UoM { get; set; } = "Unit";

        [DataType(DataType.Currency)]
        public decimal? TargetUnitPrice { get; set; }

        public string Notes { get; set; }

        public string Details { get; set; }

        [StringLength(100)]
        public string SalesWarranty { get; set; }
    }

    // --- Sub-ViewModel untuk "Request Item to Purchasing" ---
    public class RfqCreatePurchasingRequestItemViewModel
    {
        public int? ItemID_IfExists { get; set; }

        [StringLength(255)]
        public string RequestedItemName { get; set; }

        public string RequestedItemDescription { get; set; }

        [Required(ErrorMessage = "Kuantitas harus diisi.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Kuantitas harus lebih besar dari 0.")]
        public decimal Quantity { get; set; } = 1;

        [StringLength(20)]
        public string UoM { get; set; } = "Unit";

        [Required(ErrorMessage = "Alasan permintaan harus diisi.")]
        [StringLength(100)]
        public string ReasonForRequest { get; set; }

        public string SalesNotes { get; set; }

        public int? AssignedToPurchasingUserID { get; set; }
    }

    // --- Sub-ViewModel untuk "Survey List" ---
    public class RfqCreateSurveyRequestItemViewModel
    {
        [Required(ErrorMessage = "Kategori survei harus dipilih.")]
        public int SurveyCategoryID { get; set; }

        [StringLength(255)]
        public string SurveyName { get; set; }

        [StringLength(150)]
        public string CustomerPICName { get; set; }

        public List<int> TechnicalUserIDs { get; set; }

        [Required(ErrorMessage = "Tanggal & Waktu survei yang diminta harus diisi.")]
        [DataType(DataType.DateTime)]
        public DateTime RequestedDateTime { get; set; } = DateTime.Now.AddDays(1);

        public string LocationDetails { get; set; }

        public string SalesNotesInternal { get; set; }

        public RfqCreateSurveyRequestItemViewModel()
        {
            TechnicalUserIDs = new List<int>();
        }
    }


    // --- ViewModel Utama untuk Halaman Create RFQ ---
    public class RfqCreateFullViewModel
    {
        public int? RFQID_FromEdit { get; set; } // TAMBAHKAN BARIS INI
        // --- Properti untuk RFQ Header ---
        [Required(ErrorMessage = "Kode RFQ harus diisi.")]
        [StringLength(50)]
        public string RFQCode { get; set; }

        [Required(ErrorMessage = "Nama RFQ harus diisi.")]
        [StringLength(255)]
        public string RFQName { get; set; }

        [Required(ErrorMessage = "Customer (Company Name) harus dipilih.")]
        public int CustomerID { get; set; }

        public int? ContactPersonID { get; set; }

        [Required(ErrorMessage = "Tanggal Permintaan harus diisi.")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Tanggal Jatuh Tempo harus diisi.")]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.Today.AddDays(14);

        // --- PROPERTI YANG DITAMBAHKAN ---
        [DataType(DataType.Currency)]
        public decimal? OverallBudget { get; set; }

        [StringLength(100)]
        public string OverallLeadTime { get; set; }
        // --- AKHIR PROPERTI YANG DITAMBAHKAN ---

        [StringLength(50)]
        public string Resource { get; set; }

        public int? PersonalResourceEmployeeID { get; set; }

        [Required(ErrorMessage = "Kategori RFQ harus dipilih.")]
        public int RFQCategoryID { get; set; }

        [Required(ErrorMessage = "Peluang RFQ harus dipilih.")]
        public int RFQOpportunityID { get; set; }

        [Display(Name = "End User")]
        public int? EndUserContactPersonID { get; set; } // Untuk menampung ID End User yang dipilih
        public SelectList? EndUserContactPersonList { get; set; } // Untuk daftar pilihan End User

        // --- Koleksi untuk setiap bagian form ---
        public List<RfqCreateNoteItemViewModel> NotesSectionItems { get; set; }
        public List<RfqCreateRfqItemViewModel> ItemListSectionItems { get; set; }
        public List<RfqCreatePurchasingRequestItemViewModel> PurchasingRequestSectionItems { get; set; }
        public List<RfqCreateSurveyRequestItemViewModel> SurveySectionItems { get; set; }

        // --- Properti untuk mengisi Dropdown Lists ---
        public SelectList CustomerList { get; set; }
        public SelectList ContactPersonList { get; set; }
        public SelectList UserList { get; set; }
        public SelectList RFQCategoryList { get; set; }
        public SelectList RFQOpportunityList { get; set; }
        public SelectList ItemMasterList { get; set; }
        public SelectList SurveyCategoryList { get; set; }

        public RfqCreateFullViewModel()
        {
            NotesSectionItems = new List<RfqCreateNoteItemViewModel> { new RfqCreateNoteItemViewModel() };
            ItemListSectionItems = new List<RfqCreateRfqItemViewModel> { new RfqCreateRfqItemViewModel() };
            PurchasingRequestSectionItems = new List<RfqCreatePurchasingRequestItemViewModel> { new RfqCreatePurchasingRequestItemViewModel() };
            SurveySectionItems = new List<RfqCreateSurveyRequestItemViewModel>();


            // Inisialisasi EndUserContactPersonList agar tidak null saat view pertama kali dimuat
            EndUserContactPersonList = new SelectList(Enumerable.Empty<SelectListItem>(), "Value", "Text");
        }
    }
}
