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
    public class ReviewController : Controller
    {
        private readonly CVGSContext _context;

        public ReviewController(CVGSContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index(Guid id)
        {
            var cVGSContext = _context.Reviews.Include(r => r.Game).Include(r => r.Person).Where(r => r.GameId == id);
            var userReview = cVGSContext.Where(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")).FirstOrDefault();
            ViewData["GameName"] = _context.Game.Where(x => x.Guid == id).FirstOrDefault().EnglishName;
            ViewData["guid"] = id;
            if(userReview == null)
            {
                ViewData["ReviewWritten"] = "false";
            }
            else
            {
                ViewData["ReviewWritten"] = "true";
            }
            if(cVGSContext == null)
            {
                return NotFound();
            }
            else
            {
                return View(await cVGSContext.ToListAsync());
            }        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Game)
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Review/Create
        public async Task<IActionResult> Create(int? id, Guid guid)
        {
            var person = await _context.Person.Where(x => x.Id == id).FirstOrDefaultAsync();
            ViewData["GameName"] = _context.Game.Where(x => x.Guid == guid).First().EnglishName;
            ViewData["ReviewerName"] = person.GivenName + " " + person.Surname;
            ViewData["GameId"] = new SelectList(_context.Game, "Guid", "EnglishName", guid);
            ViewData["guid"] = guid;
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Surname", id);
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GameId,PersonId,ReviewDate,Review")] Reviews reviews)
        {
            string errors = "";
            foreach (var modelState in ModelState.Values)
            {
                foreach (var modelError in modelState.Errors)
                {
                    errors += modelError.ErrorMessage + "\n";
                }
            }
            reviews.ReviewDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { id = reviews.GameId });
            }
            ViewData["ModelError"] = errors;
            ViewData["GameId"] = new SelectList(_context.Game, "Guid", "EnglishName", reviews.GameId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "City", reviews.PersonId);
            return View(reviews);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int? id, Guid? guid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }

            var person = _context.Person.Where(x => x.Id == reviews.PersonId).First();
            ViewData["GameName"] = _context.Game.Where(x => x.Guid == guid).FirstOrDefault().EnglishName;
            ViewData["GameName"] = _context.Game.Where(x => x.Guid == reviews.GameId).First().EnglishName;
            ViewData["ReviewerName"] = person.GivenName + " " + person.Surname;
            return View(reviews);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GameId,PersonId,ReviewDate,Review")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { id = reviews.GameId });
            }
            ViewData["GameId"] = new SelectList(_context.Game, "Guid", "EnglishName", reviews.GameId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "City", reviews.PersonId);
            return View(reviews);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Game)
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Game" , new { id = reviews.GameId });
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
