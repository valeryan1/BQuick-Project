using BQuick.Data;
using BQuick.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BQuick.Controllers
{
    public class RequestController : Controller
    {
        public readonly BQuickDbContext _context;

        public RequestController(BQuickDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
