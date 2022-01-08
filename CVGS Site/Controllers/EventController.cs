using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVGS_Site.Models;

namespace CVGS_Site.Controllers
{
    public class EventController : Controller
    {
        private readonly CVGSContext _context;

        public EventController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            var cVGSContext = _context.EventLog.Include(e => e.Person);
            return View(await cVGSContext.ToListAsync());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLog = await _context.EventLog
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventLog == null)
            {
                return NotFound();
            }

            return View(eventLog);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "GivenName");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,EventName,StartDate,EndDate,Detail,Creator,PersonId")] EventLog eventLog)
        {
            if (eventLog.StartDate > eventLog.EndDate)
            {
                TempData["Error"] += "End date of event must be after start date";
                return RedirectToAction(nameof(Create));
            }
            if (ModelState.IsValid)
            {
                _context.Add(eventLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "GivenName", eventLog.PersonId);
            return View(eventLog);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLog = await _context.EventLog.FindAsync(id);
            if (eventLog == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "GivenName", eventLog.PersonId);
            return View(eventLog);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,EventName,StartDate,EndDate,Detail,Creator,PersonId")] EventLog eventLog)
        {
            if (id != eventLog.EventId)
            {
                return NotFound();
            }
            if (eventLog.StartDate > eventLog.EndDate)
            {
                TempData["Error"] += "End date of event must be after start date";
                return RedirectToAction(nameof(Edit));
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventLogExists(eventLog.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "GivenName", eventLog.PersonId);
            return View(eventLog);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventLog = await _context.EventLog
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (eventLog == null)
            {
                return NotFound();
            }

            return View(eventLog);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventLog = await _context.EventLog.FindAsync(id);
            _context.EventLog.Remove(eventLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventLogExists(int id)
        {
            return _context.EventLog.Any(e => e.EventId == id);
        }
    }
}
