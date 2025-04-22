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
            return View(await _context.RFQs.Include(r => r.Company).ToListAsync());
        }

        public IActionResult Create()
        {
            //ViewBag.RFQCode = GenerateRFQCode();

            //ViewBag.Customers = new SelectList(_context.Customers, "CustomerID", "CompanyName");

            //ViewBag.Users = new SelectList(_context.Users, "UserID", "FullName");

            return View();
        }

        public IActionResult AddCustomer()
        {
            return View();
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
