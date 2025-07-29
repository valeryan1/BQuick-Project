using System.Diagnostics;
using System.Net;
using BQuick.Data;
using BQuick.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BQuick.Controllers
{
    public class RFQController : Controller
    {
        private readonly BQuickDbContext _context;
        private const int LoggedInUserId = 1; // GANTI DENGAN MEKANISME USER ID AKTUAL

        private readonly IWebHostEnvironment _webHostEnvironment;
    
        public RFQController(BQuickDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;        
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


                viewModel.EndUserContactPersonList = new SelectList(
                    await _context.CustomerContactPersons.Where(cp => cp.CustomerID == viewModel.CustomerID).OrderBy(cp => cp.FullName).ToListAsync(),
                    "ContactPersonID", "FullName", viewModel.EndUserContactPersonID);
            }
            else
            {
                viewModel.ContactPersonList = new SelectList(new List<CustomerContactPerson>(), "ContactPersonID", "FullName");
                viewModel.EndUserContactPersonList = new SelectList(Enumerable.Empty<CustomerContactPerson>(), "ContactPersonID", "FullName"); // Pastikan inisialisasi
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
                 "SurveyCategoryID",
                 "CategoryName"
             );

            var purchasingUsers = await _context.Users
                .Where(u => u.IsActive && u.RoleID == 5)
                .OrderBy(u => u.FullName)
                .ToListAsync();
            viewModel.PurchasingUserList = new SelectList(purchasingUsers, "UserID", "FullName");


            var surveyRoleIds = new List<int> { 1, 2, 3, 4 };
            var surveyUsers = await _context.Users
                .Where(u => u.IsActive && surveyRoleIds.Contains(u.RoleID))
                .OrderBy(u => u.FullName)
                .ToListAsync();
            viewModel.SurveyUserList = new SelectList(surveyUsers, "UserID", "FullName");
        }


        // GET: RFQ/CreateFull (atau nama action Anda)
        [HttpGet]
        public async Task<IActionResult> CreateFull(int? id)  // Ganti nafx                                                                                                 11qma jika perlu
        {
            var viewModel = new RfqCreateFullViewModel();

            if (id.HasValue) // Jika ada ID, berarti mode "lanjutkan/edit"
            {
                var rfq = await _context.RFQs
                    
                    .Include(r => r.Notes)
                    .Include(r => r.Items)
                        .ThenInclude(ri => ri.Item)
                    .Include(r => r.PurchasingRequests)
                    .Include(r => r.SurveyRequests)
                        .ThenInclude(sr => sr.SurveyStatus)
                    .Include(r => r.SurveyRequests)
                        .ThenInclude(sr => sr.AssignedPICs)
                    .Include(r => r.SurveyRequests)
                        .ThenInclude(sr => sr.SurveyCategories) // Eager load categories
                    .Include(r => r.MeetingRequests)
                        .ThenInclude(mr => mr.MeetingStatus)
                    .Include(r => r.MeetingRequests)
                        .ThenInclude(mr => mr.AssignedPICs)
                    .FirstOrDefaultAsync(r => r.RFQID == id.Value);

                if (rfq == null)
                {
                    return NotFound();
                }

                viewModel.RFQID_FromEdit = rfq.RFQID;
                viewModel.RFQCode = rfq.RFQCode;
                viewModel.RFQName = rfq.RFQName;
                viewModel.CustomerID = rfq.CustomerID;
                viewModel.ContactPersonID = rfq.ContactPersonID;
                viewModel.EndUserContactPersonID = rfq.ContactPersonID;
                viewModel.RequestDate = rfq.RequestDate;
                viewModel.DueDate = rfq.DueDate;
                viewModel.OverallBudget = rfq.OverallBudget;
                viewModel.OverallLeadTime = rfq.OverallLeadTime;
                viewModel.Resource = rfq.Resource;
                viewModel.PersonalResourceEmployeeID = rfq.PersonalResourceEmployeeID;
                viewModel.RFQCategoryID = rfq.RFQCategoryID ?? 0;
                viewModel.RFQOpportunityID = rfq.RFQOpportunityID ?? 0;

                // Map related collections
                viewModel.NotesSectionItems = rfq.Notes.Select(n => new RfqCreateNoteItemViewModel
                {
                    ItemName = n.ItemName,
                    ItemDescription = n.ItemDescription,
                    Quantity = n.Quantity,
                    UoM = n.UoM,
                    BudgetTarget = n.BudgetTarget,
                    LeadTimeTarget = n.LeadTimeTarget
                }).ToList();

                viewModel.ItemListSectionItems = rfq.Items.Select(i => new RfqCreateRfqItemViewModel
                {
                    ItemID = i.ItemID,
                    ItemName = i.Item.ItemName, // Tambahkan ini
                    ItemDescription = i.Description,
                    Quantity = i.Quantity,
                    UoM = i.UoM,
                    TargetUnitPrice = i.TargetUnitPrice,
                    Notes = i.Notes,
                    Details = i.Details,
                    SalesWarranty = i.SalesWarranty
                }).ToList();

                viewModel.PurchasingRequestSectionItems = rfq.PurchasingRequests.Select(pr => new RfqCreatePurchasingRequestItemViewModel
                {
                    ItemID_IfExists = pr.ItemID_IfExists,
                    RequestedItemName = pr.RequestedItemName,
                    RequestedItemDescription = pr.RequestedItemDescription,
                    Quantity = pr.Quantity,
                    UoM = pr.UoM,
                    ReasonForRequest = pr.ReasonForRequest,
                    SalesNotes = pr.SalesNotes,
                    AssignedToPurchasingUserID = pr.AssignedToPurchasingUserID
                }).ToList();

                viewModel.SurveySectionItems = rfq.SurveyRequests.Select(sr => new RfqCreateSurveyRequestItemViewModel
                {
                    SurveyName = sr.SurveyName,
                    CustomerPICName = sr.CustomerPICName,
                    RequestStartTime = sr.RequestStartTime,
                    RequestEndTime = sr.RequestEndTime,
                    LocationDetails = sr.LocationDetails,
                    SalesNotesInternal = sr.SalesNotesInternal,
                    SurveyStatus = sr.SurveyStatus.Name,
                    TechnicalUserIDs = sr.AssignedPICs.Select(sp => sp.TechnicalUserID).ToList(),
                    SurveyCategoryIDs = sr.SurveyCategories.Select(sc => sc.SurveyCategoryID).ToList() // Map the category IDs
                }).ToList();

                viewModel.MeetingSectionItems = rfq.MeetingRequests.Select(mr => new RfqCreateMeetingItemViewModel
                {
                    MeetingName = mr.MeetingName,
                    MeetingStartTime = mr.MeetingStartTime,
                    MeetingEndTime = mr.MeetingEndTime,
                    LocationDetails = mr.LocationDetails,
                    NotesInternal = mr.NotesInternal,
                    MeetingStatusID = mr.MeetingStatusID,
                    MeetingStatusName = mr.MeetingStatus.Name,
                    AssignedPICs = mr.AssignedPICs.Select(mp => mp.UserID).ToList()
                }).ToList();

                viewModel.ExistingAttachments = await _context.RFQAttachments
                   .Where(a => a.RFQID == id.Value)
                   .ToListAsync();
            }
            else // Mode Create Baru
            {
                viewModel.RFQCode = GenerateUniqueRFQCode(); // Generate calon kode untuk ditampilkan
                                                             // (kode final akan di-generate ulang saat POST)
            }

            // Panggil ini setelah viewModel.CustomerID terisi (baik dari RFQ yang ada atau dari create baru jika ada default)
            // agar dropdown ContactPerson dan EndUser terisi dengan benar.
            await PopulateDropdownsForCreateFullAsync(viewModel);
            return View("Create", viewModel); // Menggunakan view Create.cshtml
        }



        // POST: RFQ/CreateFull
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFull(RfqCreateFullViewModel viewModel)
        {

            const int LoggedInUserId = 1;


            // DEBUG: Log all ModelState errors, regardless of IsValid
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("DEBUG: ModelState is NOT valid. Errors:");
                foreach (var modelStateEntry in ModelState.Values)
                {
                    foreach (var error in modelStateEntry.Errors)
                    {
                        Debug.WriteLine($"  - {error.ErrorMessage}");
                    }
                }

                if (viewModel.RFQID_FromEdit > 0)
                {
                    viewModel.ExistingAttachments = await _context.RFQAttachments
                        .Where(a => a.RFQID == viewModel.RFQID_FromEdit)
                        .ToListAsync();
                }

                await PopulateDropdownsForCreateFullAsync(viewModel);
                return View("Create", viewModel);
            }

            else
            {
                Debug.WriteLine("DEBUG: ModelState is valid.");
            }

            // DEBUG: Log key ViewModel properties
            Debug.WriteLine($"DEBUG: ViewModel.RFQName: {viewModel.RFQName}");
            Debug.WriteLine($"DEBUG: ViewModel.CustomerID: {viewModel.CustomerID}");
            Debug.WriteLine($"DEBUG: ViewModel.EndUserContactPersonID: {viewModel.EndUserContactPersonID}");
            Debug.WriteLine($"DEBUG: ViewModel.RequestDate: {viewModel.RequestDate}");
            Debug.WriteLine($"DEBUG: ViewModel.DueDate: {viewModel.DueDate}");

            // =================== START ATTACHMENT DEBUGGING ===================
            if (viewModel.AttachmentFiles == null)
            {
                Debug.WriteLine("DEBUG: AttachmentFiles is NULL.");
            }
            else
            {
                Debug.WriteLine($"DEBUG: AttachmentFiles Count: {viewModel.AttachmentFiles.Count}");
                foreach (var file in viewModel.AttachmentFiles)
                {
                    Debug.WriteLine($"  - File: {file.FileName}, Size: {file.Length}");
                }
            }
            // ===================  END ATTACHMENT DEBUGGING  ===================

            if (viewModel.ItemListSectionItems != null)
            {
                Debug.WriteLine($"DEBUG: ItemListSectionItems Count: {viewModel.ItemListSectionItems.Count}");
                for (int i = 0; i < viewModel.ItemListSectionItems.Count; i++)
                {
                    var item = viewModel.ItemListSectionItems[i];
                    Debug.WriteLine($"  Item {i}: ItemID={item.ItemID}, Desc={item.ItemDescription}, Qty={item.Quantity}, Notes={item.Notes}, Details={item.Details}, SalesWarranty={item.SalesWarranty}");
                }
            }

            // Custom validation for ItemListSectionItems
            if (viewModel.ItemListSectionItems != null)
            {
                for (int i = 0; i < viewModel.ItemListSectionItems.Count; i++)
                {
                    var item = viewModel.ItemListSectionItems[i];

                    // A row is considered to have data if any of its fields are filled.
                    bool rowHasData = !string.IsNullOrWhiteSpace(item.ItemDescription) ||
                                      (item.Quantity != 1) || // Default is 1, check if it's different
                                      item.TargetUnitPrice.HasValue ||
                                      !string.IsNullOrWhiteSpace(item.Notes) ||
                                      !string.IsNullOrWhiteSpace(item.Details) ||
                                      !string.IsNullOrWhiteSpace(item.SalesWarranty);

                    // If the row has data but no ItemID, it's a validation error.
                    if (rowHasData && (item.ItemID == null || item.ItemID == 0))
                    {
                        ModelState.AddModelError($"ItemListSectionItems[{i}].ItemID", $"Row {i + 1}: Item must be selected when other data in the row is filled.");
                    }
                }
            }

            if (ModelState.IsValid) 
            {
                // Gunakan transaction untuk memastikan semua data berhasil disimpan atau tidak sama sekali
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // 1. Buat dan Simpan Entitas RFQ Utama
                        var rfqEntity = new RFQ
                        {
                            RFQName = viewModel.RFQName,
                            CustomerID = viewModel.CustomerID,
                            ContactPersonID = viewModel.EndUserContactPersonID,
                            RequestDate = viewModel.RequestDate,
                            DueDate = viewModel.DueDate,
                            OverallBudget = viewModel.OverallBudget,
                            OverallLeadTime = viewModel.OverallLeadTime,
                            Resource = viewModel.Resource,
                            PersonalResourceEmployeeID = viewModel.PersonalResourceEmployeeID,
                            RFQCategoryID = viewModel.RFQCategoryID,
                            RFQOpportunityID = viewModel.RFQOpportunityID,
                            CreatedByUserID = LoggedInUserId,
                            RFQStatusID = 1, // Asumsi ID 1 = Status Awal
                            RFQCode = "RFQ-TEMP-" + DateTime.Now.Ticks // Kode sementara
                        };
                        _context.RFQs.Add(rfqEntity);
                        await _context.SaveChangesAsync(); // Simpan untuk mendapatkan RFQID

                        // Update RFQCode dengan ID yang baru didapat
                        rfqEntity.RFQCode = $"RFQ{DateTime.Now:yy}{rfqEntity.RFQID:D4}";
                      


                        // 2. Simpan RFQ Notes
                        if (viewModel.NotesSectionItems != null && viewModel.NotesSectionItems.Any())
                        {
                            foreach (var noteVm in viewModel.NotesSectionItems.Where(n => !string.IsNullOrEmpty(n.ItemName)))
                            {
                                var noteEntity = new RFQNote
                                {
                                    RFQID = rfqEntity.RFQID,
                                    ItemName = noteVm.ItemName,
                                    ItemDescription = noteVm.ItemDescription,
                                    Quantity = noteVm.Quantity,
                                    UoM = noteVm.UoM,
                                    BudgetTarget = noteVm.BudgetTarget,
                                    LeadTimeTarget = noteVm.LeadTimeTarget
                                };
                                _context.RFQNotes.Add(noteEntity);
                            }
                        }

                        // 3. Simpan RFQ Items (dari tabel Item List)
                        if (viewModel.ItemListSectionItems != null && viewModel.ItemListSectionItems.Any())
                        {
                            foreach (var itemVm in viewModel.ItemListSectionItems.Where(i => i.ItemID > 0))
                            {
                                var itemEntity = new RFQ_Item
                                {
                                    RFQID = rfqEntity.RFQID,
                                    ItemID = itemVm.ItemID,
                                    Description = itemVm.ItemDescription,
                                    Quantity = itemVm.Quantity,
                                    UoM = itemVm.UoM,
                                    TargetUnitPrice = itemVm.TargetUnitPrice,
                                    Notes = string.IsNullOrWhiteSpace(itemVm.Notes) ? null : itemVm.Notes,
                                    Details = string.IsNullOrWhiteSpace(itemVm.Details) ? null : itemVm.Details,
                                    SalesWarranty = string.IsNullOrWhiteSpace(itemVm.SalesWarranty) ? null : itemVm.SalesWarranty
                                };
                                _context.RFQ_Items.Add(itemEntity);
                            }
                        }

                        // 4. Simpan Purchasing Requests
                        if (viewModel.PurchasingRequestSectionItems != null && viewModel.PurchasingRequestSectionItems.Any())
                        {
                            foreach (var prVm in viewModel.PurchasingRequestSectionItems.Where(p => !string.IsNullOrWhiteSpace(p.RequestedItemName)))
                            {
                                var purchasingRequestEntity = new PurchasingRequest
                                {
                                    RFQID = rfqEntity.RFQID,
                                    ItemID_IfExists = prVm.ItemID_IfExists,
                                    RequestedItemName = prVm.RequestedItemName,
                                    RequestedItemDescription = prVm.RequestedItemDescription,
                                    Quantity = prVm.Quantity,
                                    UoM = prVm.UoM,
                                    ReasonForRequest = prVm.ReasonForRequest,
                                    SalesNotes = prVm.SalesNotes,
                                    AssignedToPurchasingUserID = prVm.AssignedToPurchasingUserID,
                                    RequestedByUserID = LoggedInUserId,
                                    PurchasingStatusID = 1, // Assuming 1 = "Open"
                                    RequestDate = DateTime.UtcNow
                                };
                                _context.PurchasingRequests.Add(purchasingRequestEntity);
                            }
                        }

                        // 5. Simpan Survey Requests
                        if (viewModel.SurveySectionItems != null && viewModel.SurveySectionItems.Any())
                        {
                            foreach (var surveyVm in viewModel.SurveySectionItems)
                            {
                                if (surveyVm == null) // Safely skip null items
                                {
                                    continue;
                                }

                                // Consider a row for saving if it has any meaningful data
                                bool isRowEmpty = string.IsNullOrWhiteSpace(surveyVm.SurveyName) &&
                                                  string.IsNullOrWhiteSpace(surveyVm.CustomerPICName) &&
                                                  string.IsNullOrWhiteSpace(surveyVm.LocationDetails) &&
                                                  string.IsNullOrWhiteSpace(surveyVm.SalesNotesInternal) &&
                                                  (surveyVm.SurveyCategoryIDs == null || !surveyVm.SurveyCategoryIDs.Any()) &&
                                                  (surveyVm.TechnicalUserIDs == null || !surveyVm.TechnicalUserIDs.Any()) &&
                                                  !surveyVm.RequestStartTime.HasValue &&
                                                  !surveyVm.RequestEndTime.HasValue;

                                if (isRowEmpty)
                                {
                                    continue;
                                }

                                var surveyEntity = new SurveyRequest
                                {
                                    RFQID = rfqEntity.RFQID,
                                    SurveyName = surveyVm.SurveyName,
                                    CustomerPICName = surveyVm.CustomerPICName,
                                    LocationDetails = surveyVm.LocationDetails,
                                    SalesNotesInternal = surveyVm.SalesNotesInternal,
                                    RequestStartTime = surveyVm.RequestStartTime,
                                    RequestEndTime = surveyVm.RequestEndTime,
                                    SurveyStatusID = 1, // ID 1 = "Not Yet (Sales Request)"
                                    CreatedByUserID = LoggedInUserId,
                                    SurveyCode = GenerateUniqueRFQCode() // Kode sementara
                                };
                                _context.SurveyRequests.Add(surveyEntity);

                                // Menangani relasi many-to-many untuk Kategori
                                if (surveyVm.SurveyCategoryIDs != null && surveyVm.SurveyCategoryIDs.Any())
                                {
                                    var selectedCategories = await _context.SurveyCategories
                                        .Where(sc => surveyVm.SurveyCategoryIDs.Contains(sc.SurveyCategoryID))
                                        .ToListAsync();
                                    surveyEntity.SurveyCategories = selectedCategories;
                                }


                                // Menangani relasi many-to-many untuk PIC melalui tabel SurveyPIC
                                if (surveyVm.TechnicalUserIDs != null && surveyVm.TechnicalUserIDs.Any())
                                {
                                    foreach (var picId in surveyVm.TechnicalUserIDs)
                                    {
                                        var surveyPic = new SurveyPIC { SurveyRequest = surveyEntity, TechnicalUserID = picId, PICApprovalStatusID = 1 };
                                        _context.SurveyPICs.Add(surveyPic);
                                    }
                                }
                            }
                        }

                        // 6. Simpan Meeting Requests
                        if (viewModel.MeetingSectionItems != null && viewModel.MeetingSectionItems.Any())
                        {
                            foreach (var meetingVm in viewModel.MeetingSectionItems.Where(m => !string.IsNullOrEmpty(m.MeetingName)))
                            {
                                var meetingEntity = new MeetingRequest
                                {
                                    RFQID = rfqEntity.RFQID,
                                    MeetingName = meetingVm.MeetingName,
                                    MeetingStartTime = meetingVm.MeetingStartTime,
                                    MeetingEndTime = meetingVm.MeetingEndTime,
                                    LocationDetails = meetingVm.LocationDetails,
                                    NotesInternal = meetingVm.NotesInternal,
                                    MeetingCode = "M-TEMP-" + DateTime.Now.Ticks, // Kode sementara
                                    PrimaryPIC_UserID = LoggedInUserId,
                                    CreatedByUserID = LoggedInUserId,
                                    MeetingStatusID = 1 // ID 1 = "Not Yet"
                                };
                                _context.MeetingRequests.Add(meetingEntity);

                                if (meetingVm.AssignedPICs != null && meetingVm.AssignedPICs.Any())
                                {
                                    foreach (var picId in meetingVm.AssignedPICs)
                                    {
                                        var meetingPic = new MeetingPIC { MeetingRequest = meetingEntity, UserID = picId, PICApprovalStatusID = 1 };
                                        _context.MeetingPICs.Add(meetingPic);
                                    }
                                }
                            }
                        }

                        // 7. Simpan Attachments
                        if (viewModel.AttachmentFiles != null && viewModel.AttachmentFiles.Any())
                        {
                            string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "attachment/rfq");
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }

                            try
                            {
                                foreach (var file in viewModel.AttachmentFiles)
                                {
                                    if (file.Length > 0)
                                    {
                                        // Buat nama file unik
                                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                                        {
                                            await file.CopyToAsync(fileStream);
                                        }

                                        // Simpan informasi attachment ke database
                                        var attachment = new RFQAttachment
                                        {
                                            RFQID = rfqEntity.RFQID,
                                            FileName = file.FileName,
                                            FileURL = "/attachment/rfq/" + uniqueFileName, // Simpan path relatif
                                            UploadedByUserID = LoggedInUserId,
                                            UploadTimestamp = DateTime.UtcNow
                                        };

                                        _context.RFQAttachments.Add(attachment);
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                             
                               ModelState.AddModelError(string.Empty, "Gagal meng-upload file. Error: " + ex.Message);
                                
                            }
                        }

                        // Simpan semua perubahan untuk entitas terkait
                        await _context.SaveChangesAsync();

                        // Sekarang, setelah semua entitas disimpan dan punya ID, update kodenya
                        foreach (var survey in rfqEntity.SurveyRequests)
                        {
                            survey.SurveyCode = $"SV{DateTime.Now:yy}{survey.SurveyRequestID:D4}";
                        }
                        foreach (var meeting in rfqEntity.MeetingRequests)
                        {
                            meeting.MeetingCode = $"M{DateTime.Now:yy}{meeting.MeetingRequestID:D4}";
                        }
                        await _context.SaveChangesAsync(); // Simpan pembaruan kode

                        // Konfirmasi transaksi jika semua berhasil
                        await transaction.CommitAsync();

                        TempData["SuccessMessage"] = $"RFQ '{rfqEntity.RFQName}' berhasil dibuat.";
                        return RedirectToAction(nameof(CreateFull), new { id = rfqEntity.RFQID });
                    }
                    catch (Exception ex)
                    {
                        // Jika terjadi error, batalkan semua perubahan
                        await transaction.RollbackAsync();
                        // Simpan detail error ke TempData untuk ditampilkan di view
                        TempData["ErrorMessage"] = $"An error occurred while saving: {ex.Message} Inner Exception: {ex.InnerException?.Message}";
                        ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data. Silakan coba lagi.");
                    }

                }
            }

            // Jika model tidak valid, tetap tampilkan form dengan pesan error
            else
            {
                // Tambahkan blok ini untuk melihat error saat debugging
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Debug.WriteLine($"Model Error: {error.ErrorMessage}");
                }
            }

            await PopulateDropdownsForCreateFullAsync(viewModel);
            return View("Create", viewModel);
        }







        // Action Details dan Index seperti sebelumnya
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfq = await _context.RFQs
                .Include(r => r.Customer)
                .Include(r => r.ContactPerson)
                .Include(r => r.RFQCategory)
                .Include(r => r.RFQOpportunity)
                .Include(r => r.RFQStatus)
                .Include(r => r.CreatedByUser)
                .Include(r => r.PersonalResourceEmployee)
                .Include(r => r.Notes)
                .Include(r => r.Items)
                    .ThenInclude(ri => ri.Item)
                .Include(r => r.PurchasingRequests)
                    .ThenInclude(pr => pr.PurchasingStatus)
                .Include(r => r.PurchasingRequests)
                    .ThenInclude(pr => pr.RequestedByUser)
                .Include(r => r.SurveyRequests)
                    .ThenInclude(sr => sr.SurveyStatus)
                .Include(r => r.SurveyRequests)
                    .ThenInclude(sr => sr.AssignedPICs)
                        .ThenInclude(sp => sp.TechnicalUser)
                .Include(r => r.MeetingRequests)
                    .ThenInclude(mr => mr.MeetingStatus)
                .Include(r => r.MeetingRequests)
                    .ThenInclude(mr => mr.AssignedPICs)
                        .ThenInclude(mp => mp.User)
                .FirstOrDefaultAsync(m => m.RFQID == id);

            if (rfq == null)
            {
                return NotFound();
            }

            return View(rfq);
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

        /*   public async Task<IActionResult> Index()
           {
               *//*var rfqs = await _context.RFQs
                   .Include(r => r.Company)
                   .ToListAsync();
               return View(rfqs);*//*
               return View();
           }*/


        ///=============================================



        /// ====================================================================================


        /*public IActionResult Create()
        {
            //ViewBag.RFQCode = GenerateRFQCode();
            var product = _context.PurchasingRequests.ToList();
            return View(product);
        }*/
        private static Random random = new Random();

        private string GenerateUniqueRFQCode()
        {
            var yearTwoDigits = DateTime.Now.ToString("yy"); // Misal "25"
            var prefix = $"RFQ{yearTwoDigits}"; // Misal "RFQ25"

            // Generate 4 angka acak antara 0000 dan 9999
            // random.Next(0, 10000) akan menghasilkan angka antara 0 dan 9999.
            // Format "D4" akan memastikan ada padding nol di depan jika angkanya kurang dari 4 digit.
            string uniqueNumericPart = random.Next(0, 10000).ToString("D4");

            return $"{prefix}{uniqueNumericPart}"; // Contoh: RFQ251234, RFQ250087
        }

        private string GenerateUniqueSurveyCode()
        {
            var yearTwoDigits = DateTime.Now.ToString("yy"); // Misal "25"
            var prefix = $"SRV{yearTwoDigits}"; // Misal "RFQ25"

            // Generate 4 angka acak antara 0000 dan 9999
            // random.Next(0, 10000) akan menghasilkan angka antara 0 dan 9999.
            // Format "D4" akan memastikan ada padding nol di depan jika angkanya kurang dari 4 digit.
            string uniqueNumericPart = random.Next(0, 10000).ToString("D4");

            return $"{prefix}{uniqueNumericPart}"; // Contoh: RFQ251234, RFQ250087
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
