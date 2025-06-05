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
                "SurveyCategoryID", "CategoryName", viewModel.SurveySectionItems.FirstOrDefault()?.SurveyCategoryID);
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
        public async Task<IActionResult> Create(RfqCreateFullViewModel viewModel)
        {
            // Asumsi untuk Tahap 1: ini adalah pembuatan RFQ baru
            // Nantinya Anda akan menambahkan logika untuk membedakan user role.
            // Untuk sekarang, kita fokus pada logika penyimpanan Tahap 1.
            bool isCreatingNewRfqByAdminSales = !viewModel.RFQID_FromEdit.HasValue;

            if (isCreatingNewRfqByAdminSales)
            {
                // Validasi dasar untuk Tahap 1
                if (string.IsNullOrWhiteSpace(viewModel.RFQName))
                    ModelState.AddModelError(nameof(viewModel.RFQName), "RFQ Name harus diisi.");
                if (viewModel.CustomerID == 0) // CustomerID dari hidden input, diisi setelah pilih/create customer
                    ModelState.AddModelError(nameof(viewModel.CustomerID), "Company Name harus dipilih atau dibuat.");
                if (!viewModel.EndUserContactPersonID.HasValue || viewModel.EndUserContactPersonID == 0)
                    ModelState.AddModelError(nameof(viewModel.EndUserContactPersonID), "End User harus dipilih atau dibuat.");

                // Validasi untuk NotesSectionItems
                if (viewModel.NotesSectionItems != null)
                {
                    // DEBUG: Lihat isi NotesSectionItems yang diterima dari form SEBELUM RemoveAll
                    System.Diagnostics.Debug.WriteLine($"Jumlah NotesSectionItems diterima: {viewModel.NotesSectionItems.Count}");
                    for (int k = 0; k < viewModel.NotesSectionItems.Count; k++)
                    {
                        var item = viewModel.NotesSectionItems[k];
                        System.Diagnostics.Debug.WriteLine($"SEBELUM Remove - Note Item [{k}]: Name='{item.ItemName}', Desc='{item.ItemDescription}'");
                    }

                    // LANGKAH 1: Hapus dulu baris yang sepenuhnya kosong 
                    // (di mana kedua field wajibnya, ItemName DAN ItemDescription, kosong)
                    viewModel.NotesSectionItems.RemoveAll(n =>
                        string.IsNullOrWhiteSpace(n.ItemName) &&
                        string.IsNullOrWhiteSpace(n.ItemDescription)
                    );

                    // DEBUG: Lihat isi NotesSectionItems SETELAH RemoveAll
                    System.Diagnostics.Debug.WriteLine($"Jumlah NotesSectionItems SETELAH RemoveAll: {viewModel.NotesSectionItems.Count}");
                    for (int k = 0; k < viewModel.NotesSectionItems.Count; k++)
                    {
                        var item = viewModel.NotesSectionItems[k];
                        System.Diagnostics.Debug.WriteLine($"SETELAH Remove - Note Item [{k}]: Name='{item.ItemName}', Desc='{item.ItemDescription}'");
                    }

                    // LANGKAH 2: Kemudian, validasi setiap baris yang TERSISA 
                    // (yang dianggap "digunakan" karena setidaknya salah satu dari ItemName atau ItemDescription sudah diisi)
                    for (int i = 0; i < viewModel.NotesSectionItems.Count; i++)
                    {
                        var note = viewModel.NotesSectionItems[i];

                        // Karena baris yang sepenuhnya kosong sudah dihapus,
                        // setiap 'note' di sini pasti memiliki ItemName atau ItemDescription (atau keduanya) yang terisi.
                        // Jadi, kita sekarang hanya perlu memastikan bahwa jika satu diisi, yang lain juga diisi.
                        if (string.IsNullOrWhiteSpace(note.ItemName))
                        {
                            // Ini akan terpicu jika ItemDescription diisi, tapi ItemName tidak.
                            ModelState.AddModelError($"NotesSectionItems[{i}].ItemName", "Item Name di Notes wajib diisi jika baris digunakan (Item Description terisi).");
                        }
                        if (string.IsNullOrWhiteSpace(note.ItemDescription))
                        {
                            // Ini akan terpicu jika ItemName diisi, tapi ItemDescription tidak.
                            ModelState.AddModelError($"NotesSectionItems[{i}].ItemDescription", "Item Description di Notes wajib diisi jika baris digunakan (Item Name terisi).");
                        }

                        if (string.IsNullOrWhiteSpace(note.LeadTimeTarget))
                        {
                            ModelState.Remove($"NotesSectionItems[{i}].LeadTimeTarget");
                        }
                    }
                }

                // Validasi agar ItemListSectionItems dan PurchasingRequestSectionItems harus kosong
                //if (viewModel.ItemListSectionItems != null && viewModel.ItemListSectionItems.Count > 0)
                //{
                //    ModelState.AddModelError(nameof(viewModel.ItemListSectionItems), "Daftar Item harus kosong pada tahap ini.");
                //}
                //if (viewModel.PurchasingRequestSectionItems != null && viewModel.PurchasingRequestSectionItems.Count > 0)
                //{
                //    ModelState.AddModelError(nameof(viewModel.PurchasingRequestSectionItems), "Daftar Purchasing Request harus kosong pada tahap ini.");
                //}

                if (viewModel.ItemListSectionItems != null && viewModel.ItemListSectionItems.Count == 1)
                {
                    // Asumsikan item pertama adalah default yang tidak diisi
                    ModelState.Remove("ItemListSectionItems[0].ItemID");
                    ModelState.Remove("ItemListSectionItems[0].Quantity"); // Meskipun defaultnya 1, jika ItemID tidak valid, ini bisa jadi error
                    ModelState.Remove("ItemListSectionItems[0].Notes");
                    ModelState.Remove("ItemListSectionItems[0].Details");
                    ModelState.Remove("ItemListSectionItems[0].SalesWarranty");
                    // Tambahkan field lain dari RfqCreateRfqItemViewModel jika perlu
                }
                viewModel.ItemListSectionItems?.Clear(); // Tetap panggil Clear()

                if (viewModel.PurchasingRequestSectionItems != null && viewModel.PurchasingRequestSectionItems.Count == 1)
                {
                    // Asumsikan item pertama adalah default yang tidak diisi
                    ModelState.Remove("PurchasingRequestSectionItems[0].ReasonForRequest");
                    ModelState.Remove("PurchasingRequestSectionItems[0].Quantity");
                    ModelState.Remove("PurchasingRequestSectionItems[0].RequestedItemName");
                    ModelState.Remove("PurchasingRequestSectionItems[0].RequestedItemDescription");
                    ModelState.Remove("PurchasingRequestSectionItems[0].SalesNotes");
                    // Tambahkan field lain dari RfqCreatePurchasingRequestItemViewModel jika perlu
                }
                viewModel.PurchasingRequestSectionItems?.Clear(); // Tetap panggil Clear()

                // Hapus error validasi untuk field yang di-disable/hide di Tahap 1
                ModelState.Remove(nameof(viewModel.RequestDate));
                ModelState.Remove(nameof(viewModel.DueDate));
                ModelState.Remove(nameof(viewModel.OverallBudget));
                ModelState.Remove(nameof(viewModel.OverallLeadTime));
                ModelState.Remove(nameof(viewModel.Resource));
                ModelState.Remove(nameof(viewModel.PersonalResourceEmployeeID));
                // RFQCategoryID dan RFQOpportunityID sudah nullable, jadi tidak perlu dihapus dari ModelState
                // jika memang tidak ada validasi [Required] di ViewModel untuk field tersebut.
                // Jika ada [Required] dan Anda ingin mengabaikannya untuk Tahap 1, maka hapus:
                // ModelState.Remove(nameof(viewModel.RFQCategoryID));
                // ModelState.Remove(nameof(viewModel.RFQOpportunityID));

                // Kosongkan list yang tidak diisi di Tahap 1 untuk menghindari validasi dari item kosong default
                viewModel.SurveySectionItems?.Clear();
            }
            

            if (ModelState.IsValid)
            {
                if (isCreatingNewRfqByAdminSales)
                {
                    var rfqEntity = new RFQ
                    {
                        RFQCode = GenerateUniqueRFQCode(), // Menggunakan 4 angka random
                        RFQName = viewModel.RFQName,
                        CustomerID = viewModel.CustomerID,
                        ContactPersonID = viewModel.EndUserContactPersonID,

                        RequestDate = viewModel.RequestDate, // Diisi nanti
                        DueDate = viewModel.DueDate,     // Diisi nanti
                        OverallBudget = null,
                        OverallLeadTime = null,
                        Resource = null,
                        PersonalResourceEmployeeID = null,
                        RFQCategoryID = viewModel.RFQCategoryID, // Akan null jika tidak dipilih & sudah int?
                        RFQOpportunityID = viewModel.RFQOpportunityID, // Akan null jika tidak dipilih & sudah int?

                        // Tentukan ID yang tepat untuk "Waiting Assign" dari tabel RFQStatus Anda
                        RFQStatusID = 2, // Misalnya ID 2 adalah "Waiting Assign (New Customer)" atau status "Waiting Assign" general Anda

                        CreatedByUserID = LoggedInUserId,
                        CreationTimestamp = DateTime.UtcNow,
                        LastUpdateTimestamp = DateTime.UtcNow,
                        AssignedToAdminSalesID = null
                    };
                    _context.RFQs.Add(rfqEntity);

                    try
                    {
                        // SaveChanges pertama untuk RFQ header agar RFQID ter-generate
                        await _context.SaveChangesAsync();

                        // Simpan RFQ Notes
                        if (viewModel.NotesSectionItems != null && viewModel.NotesSectionItems.Any())
                        {
                            foreach (var noteVm in viewModel.NotesSectionItems)
                            {
                                // Validasi lagi di sini sebelum add, karena RemoveAll di atas mungkin tidak menangkap semua skenario
                                if (!string.IsNullOrWhiteSpace(noteVm.ItemName) && !string.IsNullOrWhiteSpace(noteVm.ItemDescription))
                                {
                                    var rfqNoteEntity = new RFQNote
                                    {
                                        RFQID = rfqEntity.RFQID, // Menggunakan RFQID dari RFQ yang baru disimpan
                                        ItemName = noteVm.ItemName,
                                        ItemDescription = noteVm.ItemDescription,
                                        // Set default 0 atau 1 jika Quantity/BudgetTarget tidak diisi dan non-nullable di DB
                                        Quantity = noteVm.Quantity > 0 ? noteVm.Quantity : 0, // Atau default lain yang sesuai
                                        UoM = noteVm.UoM,
                                        BudgetTarget = noteVm.BudgetTarget,
                                        LeadTimeTarget = noteVm.LeadTimeTarget
                                    };
                                    _context.RFQNotes.Add(rfqNoteEntity);
                                }
                            }
                        }

                        // Simpan Lampiran (Attachments)
                        if (viewModel.AttachmentFiles != null && viewModel.AttachmentFiles.Any())
                        {
                            string rfqAttachmentBasePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "attachments", "rfq", rfqEntity.RFQID.ToString());
                            Directory.CreateDirectory(rfqAttachmentBasePath);

                            foreach (var file in viewModel.AttachmentFiles)
                            {
                                if (file.Length > 0 && file.Length <= 5 * 1024 * 1024)
                                {
                                    var originalFileName = Path.GetFileName(file.FileName);
                                    var uniqueStoredFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(originalFileName)}";
                                    var filePathOnServer = Path.Combine(rfqAttachmentBasePath, uniqueStoredFileName);

                                    using (var stream = new FileStream(filePathOnServer, FileMode.Create))
                                    {
                                        await file.CopyToAsync(stream);
                                    }

                                    var rfqAttachmentEntity = new RFQAttachment
                                    {
                                        RFQID = rfqEntity.RFQID,
                                        FileName = originalFileName,
                                        FileURL = $"/attachments/rfq/{rfqEntity.RFQID}/{uniqueStoredFileName}",
                                        UploadTimestamp = DateTime.UtcNow,
                                        UploadedByUserID = LoggedInUserId
                                    };
                                    _context.RFQAttachments.Add(rfqAttachmentEntity);
                                }
                            }
                        }

                        // SaveChanges kedua untuk Notes dan Attachments
                        await _context.SaveChangesAsync();

                        TempData["SuccessMessage"] = $"RFQ '{rfqEntity.RFQName}' (Code: {rfqEntity.RFQCode}) berhasil dibuat dan menunggu assignment.";
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateException ex)
                    {
                        ModelState.AddModelError("", "Terjadi kesalahan saat menyimpan RFQ: " + ex.Message + (ex.InnerException != null ? " Inner: " + ex.InnerException.Message : ""));
                    }
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
