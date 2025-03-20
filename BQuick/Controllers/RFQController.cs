﻿using BQuick.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
