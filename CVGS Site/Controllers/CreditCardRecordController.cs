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
    public class CreditCardRecordController : Controller
    {
        private readonly CVGSContext _context;

        public CreditCardRecordController(CVGSContext context)
        {
            _context = context;
        }

        // GET: CreditCardRecord
        public async Task<IActionResult> Index()
        {
            //            .Where(x => x.ArtistIdMember
            //== int.Parse(HttpContext.Session.GetString("artistId")))
            var cVGSContext = _context.CreditCardRecord.Include(c => c.Person)
                .Where(c => c.PersonId == HttpContext.Session.GetInt32("loggedInPersonID").Value);

            return View(await cVGSContext.ToListAsync());
        }

        // GET: CreditCardRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardRecord = await _context.CreditCardRecord
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (creditCardRecord == null)
            {
                return NotFound();
            }

            return View(creditCardRecord);
        }

        // GET: CreditCardRecord/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: CreditCardRecord/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CardId,PersonId,CardNumber,ExpiryDateMonth,ExpiryDateYear,Cvv")] CreditCardRecord creditCardRecord)
        {
            if (ModelState.IsValid)
            {
                creditCardRecord = TagPersonIdAndCompanyCode(creditCardRecord);

                _context.Add(creditCardRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", creditCardRecord.PersonId);
            return View(creditCardRecord);
        }

        // GET: CreditCardRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardRecord = await _context.CreditCardRecord.FindAsync(id);
            if (creditCardRecord == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", creditCardRecord.PersonId);
            return View(creditCardRecord);
        }

        // POST: CreditCardRecord/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CardId,PersonId,CardNumber,ExpiryDateMonth,ExpiryDateYear,Cvv")] CreditCardRecord creditCardRecord)
        {
            if (id != creditCardRecord.CardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    creditCardRecord = TagPersonIdAndCompanyCode(creditCardRecord);
                    _context.Update(creditCardRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditCardRecordExists(creditCardRecord.CardId))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", creditCardRecord.PersonId);
            return View(creditCardRecord);
        }

        // GET: CreditCardRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditCardRecord = await _context.CreditCardRecord
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.CardId == id);
            if (creditCardRecord == null)
            {
                return NotFound();
            }

            return View(creditCardRecord);
        }

        // POST: CreditCardRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditCardRecord = await _context.CreditCardRecord.FindAsync(id);
            _context.CreditCardRecord.Remove(creditCardRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditCardRecordExists(int id)
        {
            return _context.CreditCardRecord.Any(e => e.CardId == id);
        }

        public CreditCardRecord TagPersonIdAndCompanyCode(CreditCardRecord creditCardRecord)
        {
            creditCardRecord.PersonId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
            var card = _context.CreditCard;
            if (creditCardRecord.CardNumber.StartsWith("51") || creditCardRecord.CardNumber.StartsWith("52")
                || creditCardRecord.CardNumber.StartsWith("53") || creditCardRecord.CardNumber.StartsWith("54")
                || creditCardRecord.CardNumber.StartsWith("55"))
            {
                creditCardRecord.CardCode = card.FirstOrDefaultAsync(x => x.CardNumberPrefixList == "'51,52,53,54,55'|").Result.Code;
            }
            else if (creditCardRecord.CardNumber.StartsWith("4"))
            {
                creditCardRecord.CardCode = card.FirstOrDefaultAsync(x => x.CardNumberPrefixList == "'4'|").Result.Code;
            }
            else if (creditCardRecord.CardNumber.StartsWith("34") || creditCardRecord.CardNumber.StartsWith("37"))
            {
                creditCardRecord.CardCode = card.FirstOrDefaultAsync(x => x.CardNumberPrefixList == "'34,37'|").Result.Code;
            }
            else
            {
                creditCardRecord.CardCode = "Unknown";
            }
            return creditCardRecord;
        }
    }
}
