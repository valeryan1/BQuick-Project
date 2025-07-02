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
        public async Task<IActionResult> CreateFull(int? id)  // Ganti nama jika perlu
        {
            var viewModel = new RfqCreateFullViewModel();

            if (id.HasValue) // Jika ada ID, berarti mode "lanjutkan/edit"
            {
                var rfq = await _context.RFQs
         
                    .FirstOrDefaultAsync(r => r.RFQID == id.Value);

                if (rfq == null)
                {
                    return NotFound(); // Atau handle error lain jika RFQ tidak ditemukan
                }

                // --- Melengkapi pemetaan dari entitas RFQ ke RfqCreateFullViewModel ---
                // viewModel.RFQID_FromEdit = rfq.RFQID; // Jika Anda menambahkan properti ini di ViewModel untuk menandai mode edit

                viewModel.RFQCode = rfq.RFQCode;
                viewModel.RFQName = rfq.RFQName;
                viewModel.CustomerID = rfq.CustomerID;

                // Mengisi EndUserContactPersonID (dan ContactPersonID jika fieldnya sama di ViewModel untuk tujuan berbeda)
                // Asumsi ContactPersonID di entitas RFQ adalah End User yang dipilih di Tahap 1
                viewModel.ContactPersonID = rfq.ContactPersonID ?? 0;
                viewModel.EndUserContactPersonID = rfq.ContactPersonID;

                // Mengisi field-field yang mungkin sudah diisi di tahap sebelumnya atau akan dilanjutkan
                viewModel.RequestDate = rfq.RequestDate; // Beri default jika null saat load
                viewModel.DueDate = rfq.DueDate; // Beri default jika null saat load
                viewModel.OverallBudget = rfq.OverallBudget;
                viewModel.OverallLeadTime = rfq.OverallLeadTime;
                viewModel.Resource = rfq.Resource;
                viewModel.PersonalResourceEmployeeID = rfq.PersonalResourceEmployeeID;

                // Untuk RFQCategoryID dan RFQOpportunityID, karena di model RFQ.cs tipe datanya int (non-nullable)
                // Jika nilainya 0 (default untuk int jika tidak diset dan tidak nullable di DB), 
                // Anda mungkin ingin agar dropdown tidak memilih apa-apa atau memilih opsi default "pilih..."
                // Jika nilainya valid (misalnya > 0), maka akan otomatis terpilih di dropdown oleh SelectList.
                viewModel.RFQCategoryID = rfq.RFQCategoryID ?? 0;
                viewModel.RFQOpportunityID = rfq.RFQOpportunityID ?? 0;

                
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
            if (!ModelState.IsValid)
            {
                await PopulateDropdownsForCreateFullAsync(viewModel);
                return View("Create", viewModel);
            }

            // DEBUG: Check if user with ID 1 exists
            var userExists = await _context.Users.AnyAsync(u => u.UserID == LoggedInUserId);
            Debug.WriteLine($"DEBUG: User with ID {LoggedInUserId} exists: {userExists}");

            if (!userExists)
            {
                ModelState.AddModelError("", $"Critical Error: User with ID {LoggedInUserId} does not exist. Please contact administrator.");
                await PopulateDropdownsForCreateFullAsync(viewModel);
                return View("Create", viewModel);
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
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
                        RFQCategoryID = viewModel.RFQCategoryID > 0 ? viewModel.RFQCategoryID : null,
                        RFQOpportunityID = viewModel.RFQOpportunityID > 0 ? viewModel.RFQOpportunityID : null,
                        CreatedByUserID = LoggedInUserId,
                        RFQStatusID = 1, // Default status
                        RFQCode = "RFQ-TEMP" // Temporary code
                    };

                    // 1. Map Notes
                    if (viewModel.NotesSectionItems != null)
                    {
                        foreach (var noteVm in viewModel.NotesSectionItems.Where(n => !string.IsNullOrWhiteSpace(n.ItemName)))
                        {
                            rfqEntity.Notes.Add(new RFQNote
                            {
                                ItemName = noteVm.ItemName,
                                ItemDescription = noteVm.ItemDescription,
                                Quantity = noteVm.Quantity ?? 1,
                                UoM = noteVm.UoM ?? "Unit",
                                BudgetTarget = noteVm.BudgetTarget,
                                LeadTimeTarget = noteVm.LeadTimeTarget
                            });
                        }
                    }

                    // 2. Map RFQ Items
                    if (viewModel.ItemListSectionItems != null)
                    {
                        foreach (var itemVm in viewModel.ItemListSectionItems.Where(i => i.ItemID.HasValue && i.ItemID > 0))
                        {
                            rfqEntity.Items.Add(new RFQ_Item
                            {
                                ItemID = itemVm.ItemID.Value,
                                Description = itemVm.ItemDescription,
                                Quantity = itemVm.Quantity ?? 1,
                                UoM = itemVm.UoM ?? "Unit",
                                TargetUnitPrice = itemVm.TargetUnitPrice,
                                Notes = itemVm.Notes,
                                Details = itemVm.Details,
                                SalesWarranty = itemVm.SalesWarranty
                            });
                        }
                    }

                    // 3. Map Purchasing Requests
                    if (viewModel.PurchasingRequestSectionItems != null)
                    {
                        foreach (var prVm in viewModel.PurchasingRequestSectionItems.Where(p => !string.IsNullOrWhiteSpace(p.RequestedItemName)))
                        {
                            rfqEntity.PurchasingRequests.Add(new PurchasingRequest
                            {
                                ItemID_IfExists = prVm.ItemID_IfExists,
                                RequestedItemName = prVm.RequestedItemName,
                                RequestedItemDescription = prVm.RequestedItemDescription,
                                Quantity = prVm.Quantity,
                                UoM = prVm.UoM,
                                ReasonForRequest = prVm.ReasonForRequest,
                                SalesNotes = prVm.SalesNotes,
                                AssignedToPurchasingUserID = prVm.AssignedToPurchasingUserID,
                                RequestDate = DateTime.UtcNow,
                                PurchasingStatusID = 1, // Default status
                                RequestedByUserID = LoggedInUserId
                            });
                        }
                    }

                    // 4. Map Survey Requests
                    if (viewModel.SurveySectionItems != null)
                    {
                        foreach (var surveyVm in viewModel.SurveySectionItems.Where(s => !string.IsNullOrWhiteSpace(s.SurveyName)))
                        {
                            var surveyRequest = new SurveyRequest
                            {
                                SurveyName = surveyVm.SurveyName,
                                CustomerPICName = surveyVm.CustomerPICName,
                                RequestStartTime = surveyVm.RequestStartTime,
                                RequestEndTime = surveyVm.RequestEndTime,
                                LocationDetails = surveyVm.LocationDetails,
                                SalesNotesInternal = surveyVm.SalesNotesInternal,
                                SurveyStatusID = 1, // Default status
                                CreatedByUserID = LoggedInUserId,
                                SurveyCode = "SRV-TEMP" // Placeholder
                            };

                            if (surveyVm.TechnicalUserIDs != null)
                            {
                                foreach (var techId in surveyVm.TechnicalUserIDs)
                                {
                                    surveyRequest.AssignedPICs.Add(new SurveyPIC { TechnicalUserID = techId, PICApprovalStatusID = 1 });
                                }
                            }
                            rfqEntity.SurveyRequests.Add(surveyRequest);
                        }
                    }

                    // 5. Map Meeting Requests
                    if (viewModel.MeetingSectionItems != null)
                    {
                        foreach (var meetingVm in viewModel.MeetingSectionItems.Where(m => !string.IsNullOrWhiteSpace(m.MeetingName)))
                        {
                            var meetingRequest = new MeetingRequest
                            {
                                MeetingName = meetingVm.MeetingName,
                                MeetingStartTime = meetingVm.MeetingStartTime,
                                MeetingEndTime = meetingVm.MeetingEndTime,
                                LocationDetails = meetingVm.LocationDetails,
                                NotesInternal = meetingVm.NotesInternal,
                                MeetingStatusID = 1, // Default status
                                CreatedByUserID = LoggedInUserId,
                                PrimaryPIC_UserID = LoggedInUserId, // Or choose a specific PIC
                                MeetingCode = "MTG-TEMP" // Placeholder
                            };

                            if (meetingVm.AssignedPICs != null)
                            {
                                foreach (var picId in meetingVm.AssignedPICs)
                                {
                                    meetingRequest.AssignedPICs.Add(new MeetingPIC { UserID = picId, PICApprovalStatusID = 1 });
                                }
                            }
                            rfqEntity.MeetingRequests.Add(meetingRequest);
                        }
                    }

                    _context.RFQs.Add(rfqEntity);
                    await _context.SaveChangesAsync();

                    // Update codes with the new IDs
                    rfqEntity.RFQCode = $"RFQ{DateTime.Now:yy}{rfqEntity.RFQID:D4}";
                    foreach (var survey in rfqEntity.SurveyRequests)
                    {
                        survey.SurveyCode = $"SRV{DateTime.Now:yy}{survey.SurveyRequestID:D4}";
                    }
                    foreach (var meeting in rfqEntity.MeetingRequests)
                    {
                        meeting.MeetingCode = $"MTG{DateTime.Now:yy}{meeting.MeetingRequestID:D4}";
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    TempData["SuccessMessage"] = $"RFQ '{rfqEntity.RFQName}' and its details have been successfully created.";
                    return RedirectToAction(nameof(CreateFull), new { id = rfqEntity.RFQID });
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    // Log the exception details for debugging
                    Debug.WriteLine(ex.ToString());

                    // Add a more detailed error message to the model state to be displayed on the view.
                    // This helps in diagnosing the issue directly from the UI during development.
                    var errorMessage = "An unexpected error occurred while saving the RFQ. ";
                    var innerException = ex.InnerException;
                    while (innerException != null)
                    {
                        errorMessage += $"<br/>- {innerException.Message}";
                        innerException = innerException.InnerException;
                    }
                    ModelState.AddModelError("", errorMessage);
                    ModelState.AddModelError("", $"Full error: {ex.Message}"); // Also add the top-level error
                }
            }

            await PopulateDropdownsForCreateFullAsync(viewModel);
            return View("Create", viewModel);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
