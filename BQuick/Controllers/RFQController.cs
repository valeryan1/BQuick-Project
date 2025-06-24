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
                viewModel.ContactPersonID = rfq.ContactPersonID;
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
        
            const int LoggedInUserId = 1;



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
                        await _context.SaveChangesAsync();


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
                                    Notes = itemVm.Notes,
                                    Details = itemVm.Details,
                                    SalesWarranty = itemVm.SalesWarranty
                                };
                                _context.RFQ_Items.Add(itemEntity);
                            }
                        }

                        // 4. Simpan Survey Requests
                        if (viewModel.SurveySectionItems != null && viewModel.SurveySectionItems.Any())
                        {
                            foreach (var surveyVm in viewModel.SurveySectionItems.Where(s => !string.IsNullOrEmpty(s.SurveyName)))
                            {
                                if (surveyVm == null)
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
                                    SurveyCode = "SV-TEMP" // Kode sementara
                                };
                                _context.SurveyRequests.Add(surveyEntity);

                                // Menangani relasi many-to-many untuk Kategori
                                if (surveyVm.SurveyCategoryIDs != null && surveyVm.SurveyCategoryIDs.Any())
                                {
                                    var selectedCategories = await _context.SurveyCategories.Where(c => surveyVm.SurveyCategoryIDs.Contains(c.SurveyCategoryID)).ToListAsync();
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

                        // 5. Simpan Meeting Requests
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
                                    MeetingCode = "M-TEMP",
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

                        // Simpan semua perubahan untuk entitas terkait
                        await _context.SaveChangesAsync();

                        // Konfirmasi transaksi jika semua berhasil
                        await transaction.CommitAsync();

                        TempData["SuccessMessage"] = $"RFQ '{rfqEntity.RFQName}' berhasil dibuat.";
                        return RedirectToAction(nameof(CreateFull), new { id = rfqEntity.RFQID });
                    }
                    catch (Exception ex)
                    {
                        // Jika terjadi error, batalkan semua perubahan
                        await transaction.RollbackAsync();
                        Console.WriteLine("!!!!!! TERJADI ERROR SAAT MENYIMPAN RFQ !!!!!!");
                        Console.WriteLine(ex.ToString()); // Ini akan mencetak detail error lengkap ke konsol
                        ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan data. Silakan coba lagi.");
                    }

                }
            }

            // Jika model tidak valid, tetap tampilkan form dengan pesan error
            else
            {
                // Tambahkan blok ini untuk melihat error saat debugging
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                // Letakkan breakpoint di sini untuk memeriksa isi variabel 'errors'
                // saat Anda menjalankan aplikasi dalam mode Debug.
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
