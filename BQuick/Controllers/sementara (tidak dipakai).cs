/*// File: BQuick/Controllers/RFQController.cs
// Modifikasi atau tambahkan action berikut

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BQuick.Data;
using BQuick.Models;
using BQuick.Models.ViewModels; // Pastikan namespace ViewModel benar
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace BQuick.Controllers
{
    public class RFQController : Controller
    {
        private readonly BQuickDbContext _context;
        private const int LoggedInUserId = 1; // GANTI DENGAN MEKANISME USER ID AKTUAL

        public RFQController(BQuickDbContext context)
        {
            _context = context;
        }

        
        private async Task PopulateDropdownsForCreateFullAsync(RfqCreateFullViewModel viewModel)
        {
            // Dropdown untuk Company Name
            viewModel.CustomerList = new SelectList(
                await _context.Customers.OrderBy(c => c.CompanyName).ToListAsync(),
                "CustomerID", "CompanyName", viewModel.CustomerID);

            if (viewModel.CustomerID > 0)
            {
                viewModel.ContactPersonList = new SelectList(
                    await _context.CustomerContactPersons.Where(cp => cp.CustomerID == viewModel.CustomerID).OrderBy(cp => cp.FullName).ToListAsync(),
                    "ContactPersonID", "FullName", viewModel.ContactPersonID);
            }
            else
            {
                viewModel.ContactPersonList = new SelectList(new List<CustomerContactPerson>(), "ContactPersonID", "FullName");
            }

            
            var activeUsers = await _context.Users.Where(u => u.IsActive).OrderBy(u => u.FullName).ToListAsync();
            viewModel.UserList = new SelectList(activeUsers, "UserID", "FullName", viewModel.PersonalResourceEmployeeID);
            // UserList ini juga bisa dipakai untuk PIC Purchasing dan Survey

            // Dropdown untuk Category dan Opportunity
            viewModel.RFQCategoryList = new SelectList(
                await _context.RFQCategories.OrderBy(rc => rc.Name).ToListAsync(),
                "RFQCategoryID", "Name", viewModel.RFQCategoryID);

            viewModel.RFQOpportunityList = new SelectList(
                await _context.RFQOpportunities.OrderBy(ro => ro.Name).ToListAsync(),
                "RFQOpportunityID", "Name", viewModel.RFQOpportunityID);

            // Dropdown untuk Purchasing Status dan Survey Status
            viewModel.ItemMasterList = new SelectList(
                await _context.Items.OrderBy(i => i.ItemName).ToListAsync(),
                "ItemID", "ItemName"); // ItemID (int) dari model Item Anda

            viewModel.SurveyCategoryList = new SelectList(
                await _context.SurveyCategories.OrderBy(sc => sc.CategoryName).ToListAsync(),
                "SurveyCategoryID", "CategoryName", viewModel.SurveySectionItems.FirstOrDefault()?.SurveyCategoryID);
        }


        // GET: RFQ/CreateFull (atau nama action Anda)
        [HttpGet]
        public async Task<IActionResult> CreateFull() // Ganti nama jika perlu
        {
            var viewModel = new RfqCreateFullViewModel();
            // Inisialisasi list dengan satu item kosong jika diinginkan, sudah dihandle di constructor ViewModel
            await PopulateDropdownsForCreateFullAsync(viewModel);
            return View("Create", viewModel); // Menggunakan view Create.cshtml
        }

        // POST: RFQ/CreateFull
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFull(RfqCreateFullViewModel viewModel)
        {
            // Hapus baris kosong dari list sebelum validasi
            viewModel.NotesSectionItems?.RemoveAll(n => string.IsNullOrWhiteSpace(n.ItemName) && string.IsNullOrWhiteSpace(n.ItemDescription) && n.Quantity == 1 && n.BudgetTarget == null && string.IsNullOrWhiteSpace(n.LeadTimeTarget));
            viewModel.ItemListSectionItems?.RemoveAll(i => i.ItemID == 0 && i.Quantity == 1);
            viewModel.PurchasingRequestSectionItems?.RemoveAll(p => p.ItemID_IfExists == null && string.IsNullOrWhiteSpace(p.RequestedItemName) && p.Quantity == 1);
            viewModel.SurveySectionItems?.RemoveAll(s => s.SurveyCategoryID == 0 && string.IsNullOrWhiteSpace(s.SurveyName));

            // Validasi kustom jika diperlukan (misalnya, minimal satu item di ItemList)
            if (viewModel.ItemListSectionItems == null || !viewModel.ItemListSectionItems.Any(i => i.ItemID > 0))
            {
                ModelState.AddModelError("ItemListSectionItems", "Minimal harus ada satu item valid di Item List.");
            }

            if (ModelState.IsValid)
            {
                // --- 1. Buat Entitas RFQ (Header) ---
                var rfqEntity = new RFQ
                {
                    RFQCode = viewModel.RFQCode,
                    RFQName = viewModel.RFQName,
                    CustomerID = viewModel.CustomerID,
                    ContactPersonID = viewModel.ContactPersonID,
                    RequestDate = viewModel.RequestDate,
                    DueDate = viewModel.DueDate,
                    Resource = viewModel.Resource,
                    PersonalResourceEmployeeID = viewModel.PersonalResourceEmployeeID,
                    RFQCategoryID = viewModel.RFQCategoryID,
                    RFQOpportunityID = viewModel.RFQOpportunityID,
                    RFQStatusID = (await _context.RFQStatuses.FirstOrDefaultAsync(s => s.Name == "Open"))?.RFQStatusID ?? 1, // Default status "Open"
                    CreatedByUserID = LoggedInUserId, // GANTI DENGAN USER ID YANG LOGIN
                    CreationTimestamp = DateTime.UtcNow,
                    LastUpdateTimestamp = DateTime.UtcNow
                };
                _context.RFQs.Add(rfqEntity);

                // --- 2. Simpan RFQ Notes ---
                if (viewModel.NotesSectionItems != null)
                {
                    foreach (var noteVm in viewModel.NotesSectionItems)
                    {
                        _context.RFQNotes.Add(new RFQNote
                        {
                            RFQ = rfqEntity,
                            ItemName = noteVm.ItemName,
                            ItemDescription = noteVm.ItemDescription,
                            Quantity = noteVm.Quantity,
                            UoM = noteVm.UoM,
                            BudgetTarget = noteVm.BudgetTarget,
                            LeadTimeTarget = noteVm.LeadTimeTarget
                        });
                    }
                }

                // --- 3. Simpan RFQ Items (Item List) ---
                if (viewModel.ItemListSectionItems != null)
                {
                    foreach (var itemVm in viewModel.ItemListSectionItems.Where(i => i.ItemID > 0))
                    {
                        _context.RFQ_Items.Add(new RFQ_Item
                        {
                            RFQ = rfqEntity,
                            ItemID = itemVm.ItemID,
                            Quantity = itemVm.Quantity,
                            UoM = itemVm.UoM,
                            TargetUnitPrice = itemVm.TargetUnitPrice,
                            Notes = itemVm.Notes,
                            Details = itemVm.Details,
                            SalesWarranty = itemVm.SalesWarranty
                        });
                    }
                }

                // --- 4. Simpan Purchasing Requests ---
                if (viewModel.PurchasingRequestSectionItems != null)
                {
                    foreach (var prVm in viewModel.PurchasingRequestSectionItems.Where(p => !string.IsNullOrWhiteSpace(p.RequestedItemName) || p.ItemID_IfExists.HasValue))
                    {
                        _context.PurchasingRequests.Add(new PurchasingRequest
                        {
                            RFQ = rfqEntity,
                            ItemID_IfExists = prVm.ItemID_IfExists,
                            RequestedItemName = prVm.RequestedItemName,
                            RequestedItemDescription = prVm.RequestedItemDescription,
                            Quantity = prVm.Quantity,
                            UoM = prVm.UoM,
                            ReasonForRequest = prVm.ReasonForRequest,
                            SalesNotes = prVm.SalesNotes,
                            AssignedToPurchasingUserID = prVm.AssignedToPurchasingUserID,
                            RequestDate = DateTime.UtcNow,
                            // Ambil status default untuk PurchasingRequest
                            PurchasingStatusID = (await _context.PurchasingStatuses.FirstOrDefaultAsync(ps => ps.Name == "Open"))?.PurchasingStatusID ?? 1,
                            RequestedByUserID = LoggedInUserId // User Sales yang membuat request ini
                        });
                    }
                }

                // --- 5. Simpan Survey Requests ---
                if (viewModel.SurveySectionItems != null)
                {
                    int surveyCounter = 1;
                    foreach (var srVm in viewModel.SurveySectionItems.Where(s => s.SurveyCategoryID > 0))
                    {
                        var surveyRequestEntity = new SurveyRequest
                        {
                            RFQ = rfqEntity,
                            SurveyCode = $"{rfqEntity.RFQCode}-SRV{surveyCounter++}", // Generate Survey Code
                            SurveyName = srVm.SurveyName,
                            SurveyCategoryID = srVm.SurveyCategoryID,
                            CustomerPICName = srVm.CustomerPICName,
                            RequestedDateTime = srVm.RequestedDateTime,
                            LocationDetails = srVm.LocationDetails,
                            SalesNotesInternal = srVm.SalesNotesInternal,
                            // Ambil status default untuk SurveyRequest
                            SurveyStatusID = (await _context.SurveyStatuses.FirstOrDefaultAsync(ss => ss.Name == "Not Yet"))?.SurveyStatusID ?? 1,
                            CreatedByUserID = LoggedInUserId, // User Sales yang membuat request survei
                            CreationTimestamp = DateTime.UtcNow
                        };
                        _context.SurveyRequests.Add(surveyRequestEntity);

                        // Tambahkan PIC untuk Survey
                        if (srVm.TechnicalUserIDs != null)
                        {
                            foreach (var techUserId in srVm.TechnicalUserIDs)
                            {
                                _context.SurveyPICs.Add(new SurveyPIC
                                {
                                    SurveyRequest = surveyRequestEntity,
                                    TechnicalUserID = techUserId,
                                    // Ambil status default untuk PICApprovalStatus
                                    PICApprovalStatusID = (await _context.PICApprovalStatuses.FirstOrDefaultAsync(pas => pas.Name == "Pending"))?.PICApprovalStatusID ?? 1
                                });
                            }
                        }
                    }
                }

                try
                {
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"RFQ '{rfqEntity.RFQName}' dan data terkait berhasil dibuat.";
                    return RedirectToAction("Details", new { id = rfqEntity.RFQID }); // Arahkan ke halaman detail
                }
                catch (DbUpdateException ex)
                {
                    // Log error (ex)
                    ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data: " + ex.InnerException?.Message);
                }
            }

            // Jika ModelState tidak valid, atau terjadi error saat simpan,
            // populate kembali dropdown dan tampilkan view dengan error.
            await PopulateDropdownsForCreateFullAsync(viewModel);
            return View("Create", viewModel); // Menggunakan view Create.cshtml
        }

        // Action Details dan Index seperti sebelumnya
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            // Implementasi Details seperti pada contoh sebelumnya, menggunakan RfqDisplayViewModel
            // ...
            var rfq = await _context.RFQs.FindAsync(id);
            if (rfq == null) return NotFound();
            // Untuk sementara, tampilkan view sederhana atau redirect
            // return View(rfq); // Idealnya gunakan RfqDisplayViewModel
            TempData["InfoMessage"] = $"Detail RFQ ID: {id} belum diimplementasikan sepenuhnya dengan ViewModel tampilan.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Index()
        {
            var rfqs = await _context.RFQs
                .Include(r => r.Customer)
                .Include(r => r.RFQStatus)
                .OrderByDescending(r => r.CreationTimestamp)
                .Take(20) // Batasi jumlah untuk performa awal
                .ToListAsync();
            return View(rfqs);
        }


        // Endpoint untuk mengambil Contact Person berdasarkan CustomerID (untuk AJAX)
        // Sudah ada dari contoh sebelumnya, pastikan URL di JS sesuai
        [HttpGet]
        public async Task<JsonResult> GetContactPersonsByCustomerId(int customerId)
        {
            var contactPersons = await _context.CustomerContactPersons
                                               .Where(cp => cp.CustomerID == customerId)
                                               .OrderBy(cp => cp.FullName)
                                               .Select(cp => new { Value = cp.ContactPersonID, Text = cp.FullName })
                                               .ToListAsync();
            return Json(contactPersons);
        }
    }
}
*/