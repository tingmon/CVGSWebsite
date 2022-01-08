using System;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVGS_Site.Models;
using Microsoft.AspNetCore.Http;

namespace CVGS_Site.Controllers
{
    public class GameController : Controller
    {
        private readonly CVGSContext _context;

        public GameController(CVGSContext context)
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
        // GET: Game
        public async Task<IActionResult> Index()
        {
            dynamic myModel = new ExpandoObject();
            myModel.GameList = await _context.Game.Include(g => g.EsrbRatingCodeNavigation).Include(g => g.GameCategory).Include(g => g.GamePerspectiveCodeNavigation).Include(g => g.GameStatusCodeNavigation).Include(g => g.GameSubCategory).ToListAsync();
            CheckEmployee();
            return View(myModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string search)
        {
            dynamic myModel = new ExpandoObject();
            myModel.GameList = await _context.Game
                .Include(g => g.EsrbRatingCodeNavigation)
                .Include(g => g.GameCategory)
                .Include(g => g.GamePerspectiveCodeNavigation)
                .Include(g => g.GameStatusCodeNavigation)
                .Include(g => g.GameSubCategory)
                .Where(x=>x.EnglishName.Contains(search))
                .ToListAsync();
            CheckEmployee();
            return View(myModel);
        }

        // GET: Game/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.EsrbRatingCodeNavigation)
                .Include(g => g.GameCategory)
                .Include(g => g.GamePerspectiveCodeNavigation)
                .Include(g => g.GameStatusCodeNavigation)
                .Include(g => g.GameSubCategory)
                .FirstOrDefaultAsync(m => m.Guid == id);
            CheckEmployee();
            return View(game);
        }

        // GET: Game/Create
        public IActionResult Create()
        {
            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);
                ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "EnglishRating");
                ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory");
                ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "EnglishPerspectiveName");
                ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "EnglishCategory");
                ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory");
                return View();
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Game/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Guid,GameStatusCode,GameCategoryId,GameSubCategoryId,EsrbRatingCode,EnglishName,FrenchName,FrenchVersion,EnglishPlayerCount,FrenchPlayerCount,GamePerspectiveCode,EnglishTrailer,FrenchTrailer,EnglishDescription,FrenchDescription,EnglishDetail,FrenchDetail,UserName,Rating,RatingCount,RatingTotal")] Game game)
        {

            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);
                game.Guid = Guid.NewGuid();
                if (ModelState.IsValid)
                {
                    _context.Add(game);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                string errors = "";
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        errors += modelError.ErrorMessage + "\n";
                    }
                }
                ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code", game.EsrbRatingCode);
                ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory", game.GameCategoryId);
                ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code", game.GamePerspectiveCode);
                ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code", game.GameStatusCode);
                ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory", game.GameSubCategoryId);
                ViewData["ModelError"] = errors;
                return View(game);
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Game/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);
                var game = await _context.Game.FindAsync(id);
                if (game == null)
                {
                    return NotFound();
                }
                ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code", game.EsrbRatingCode);
                ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory", game.GameCategoryId);
                ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code", game.GamePerspectiveCode);
                ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code", game.GameStatusCode);
                ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory", game.GameSubCategoryId);
                return View(game);
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
                return RedirectToAction(nameof(Index));
            }
            if (id == null)
            {
                return NotFound();
            }
        }

        // POST: Game/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Guid,GameStatusCode,GameCategoryId,GameSubCategoryId,EsrbRatingCode,EnglishName,FrenchName,FrenchVersion,EnglishPlayerCount,FrenchPlayerCount,GamePerspectiveCode,EnglishTrailer,FrenchTrailer,EnglishDescription,FrenchDescription,EnglishDetail,FrenchDetail,UserName")] Game game)
        {

            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(game);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!GameExists(game.Guid))
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
                ViewData["EsrbRatingCode"] = new SelectList(_context.EsrbRating, "Code", "Code", game.EsrbRatingCode);
                ViewData["GameCategoryId"] = new SelectList(_context.GameCategory, "Id", "EnglishCategory", game.GameCategoryId);
                ViewData["GamePerspectiveCode"] = new SelectList(_context.GamePerspective, "Code", "Code", game.GamePerspectiveCode);
                ViewData["GameStatusCode"] = new SelectList(_context.GameStatus, "Code", "Code", game.GameStatusCode);
                ViewData["GameSubCategoryId"] = new SelectList(_context.GameSubCategory, "Id", "EnglishCategory", game.GameSubCategoryId);
                return View(game);
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
                return RedirectToAction(nameof(Index));
            }
            if (id != game.Guid)
            {
                return NotFound();
            }
        }

        // GET: Game/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {

            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);
                if (id == null)
                {
                    return NotFound();
                }

                var game = await _context.Game
                    .Include(g => g.EsrbRatingCodeNavigation)
                    .Include(g => g.GameCategory)
                    .Include(g => g.GamePerspectiveCodeNavigation)
                    .Include(g => g.GameStatusCodeNavigation)
                    .Include(g => g.GameSubCategory)
                    .FirstOrDefaultAsync(m => m.Guid == id);
                if (game == null)
                {
                    return NotFound();
                }

                return View(game);
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Game/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            if (_context.Employee.Any(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")))
            {
                HttpContext.Session.SetInt32("isEmployee", 1);
                var game = await _context.Game.FindAsync(id);
                _context.Game.Remove(game);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                HttpContext.Session.SetInt32("isEmployee", 0);
                return RedirectToAction(nameof(Index));
            }
        }
        // GET: Game/Rate/5
        public async Task<IActionResult> Rate(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var game = await _context.Game
                .Include(g => g.EsrbRatingCodeNavigation)
                .Include(g => g.GameCategory)
                .Include(g => g.GamePerspectiveCodeNavigation)
                .Include(g => g.GameStatusCodeNavigation)
                .Include(g => g.GameSubCategory)
                .FirstOrDefaultAsync(m => m.Guid == id);
            if (game == null)
            {
                return NotFound();
            }
            return View(game);

        }
        // POST: Game/Rate/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rate(Guid id, Game game)
        {
            if (id == null)
            {
                return NotFound();
            }
            //find the game being rated
            var currentGame = _context.Game.Find(id);
            if (currentGame == null)
                return NotFound();
            
            //if this is the first rating update count as to not divide by zero
            if (currentGame.RatingCount == 0 || currentGame.RatingCount == null)
            {
                currentGame.RatingCount = 1;
            }
            if(game.RatingCount == null)
            {
                game.RatingCount = 0;
            }
            // add rating to total of ratings and divide by number of ratings to
            // create an average for the rating column
            currentGame.RatingCount += game.RatingCount;
            currentGame.RatingTotal += game.Rating;
            currentGame.Rating = currentGame.RatingTotal / currentGame.RatingCount;
            currentGame.RatingCount++;
            // stop the rating from exceding 100 or falling below 0
            if (currentGame.Rating >= 100)
            {
                currentGame.Rating = 100;
            }
            if (currentGame.Rating <= 0)
            {
                currentGame.Rating = 0;
            }
            _context.SaveChanges();
            return View(currentGame);
        }


        private bool GameExists(Guid id)
        {
            return _context.Game.Any(e => e.Guid == id);
        }
    }
}
