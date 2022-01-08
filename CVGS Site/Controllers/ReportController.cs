using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVGS_Site.Models;
using Microsoft.AspNetCore.Http;

namespace CVGS_Site.Controllers
{
    public class ReportController : Controller
    {
        private readonly CVGSContext _context;

        public ReportController(CVGSContext context)
        {
            _context = context;
        }

        public void CheckEmployee()
        {
            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
            }
        }
        // GET: Report
        public async Task<IActionResult> Index()
        {
            CheckEmployee();
            if(HttpContext.Session.GetInt32("isEmployee").Value == 1)
            {
                return View(await _context.Report.ToListAsync());
            }
            return RedirectToAction("Index", "Person");
        }

        // GET: Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            CheckEmployee();
            if (HttpContext.Session.GetInt32("isEmployee").Value == 1)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var report = await _context.Report
                    .FirstOrDefaultAsync(m => m.ReportId == id);
                if (report == null)
                {
                    return NotFound();
                }

                return View(report);
            }
            return RedirectToAction("Index", "Person");
        }

        // GET: Report/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportId,ReportName,ReportBody,PersonId")] Report report)
        {
            if (ModelState.IsValid)
            {
                _context.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(report);
        }

        private bool ReportExists(int id)
        {
            return _context.Report.Any(e => e.ReportId == id);
        }
    }
}
