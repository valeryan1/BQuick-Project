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
        public readonly BQuickDbContext _context;

        public RFQController(BQuickDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RFQs.Include(r => r.Customer).ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerID", "CompanyName");
            ViewBag.Users = new SelectList(_context.Users, "UserID", "FullName");
            ViewBag.RFQCode = GenerateRFQCode();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RFQName,CustomerID,RequestDate,DueDate,AssignedTo,Category,TotalBudget")] RFQ rfq, List<RFQItem> RFQItems, IFormFile attachment)
        {
            if (ModelState.IsValid)
            {
                rfq.RFQCode = GenerateRFQCode();
                rfq.CreatedAt = DateTime.Now;
                rfq.Status = "Open";

                _context.Add(rfq);
                await _context.SaveChangesAsync();

                foreach (var item in RFQItems)
                {
                    item.RFQID = rfq.RFQID;
                    _context.Add(item);
                }

                if (attachment != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await attachment.CopyToAsync(memoryStream);

                        var attachmentEntity = new Attachment
                        {
                            RelatedID = rfq.RFQID,
                            RelatedType = "RFQ",
                            FileName = attachment.FileName,
                            FileType = attachment.ContentType,
                            FileContent = memoryStream.ToArray(),
                            UploadedAt = DateTime.Now,
                            UploadedBy = rfq.CreatedBy
                        };

                        _context.Add(attachmentEntity);
                    }
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Customers = new SelectList(_context.Customers, "CustomerID", "CompanyName", rfq.CustomerID);

            ViewBag.Users = new SelectList(_context.Users, "UserID", "FullName", rfq.AssignedTo);

            return View(rfq);
        }

        private string GenerateRFQCode()
        {
            var year = DateTime.Now.ToString("yy");

            var lastRFQ = _context.RFQs.OrderByDescending(r => r.RFQID).FirstOrDefault();
            var sequenceNumber = (lastRFQ?.RFQID ?? 0) + 1;

            return $"RFQ{year}{sequenceNumber:D4}";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
