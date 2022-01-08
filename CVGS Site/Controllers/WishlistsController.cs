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
    public class WishlistsController : Controller
    {
        private readonly CVGSContext _context;

        public WishlistsController(CVGSContext context)
        {
            _context = context;
        }
        public string ExtractName(string title)
        {
            int index = title.IndexOf("- Price:");
            string trimmed = title.Remove(index);
            trimmed = trimmed.Remove(0, 3).Trim();
            return trimmed;
        }
        public void GuidToGameTitle(string ids, int flag)
        {
            string gameTitles = "";
            string[] guidList = ids.Split(',');
            foreach (var item in guidList)
            {
                if (item != "" && flag == 1)
                {
                    Guid guid = new Guid(item);
                    var game = _context.Game.FirstOrDefault(x => x.Guid == guid);
                    gameTitles = gameTitles + " - " + game.EnglishName + "       - Price: $" + game.Price + ",";
                }
                if (item != "" && flag == 0)
                {
                    Guid guid = new Guid(item);
                    var game = _context.Game.FirstOrDefault(x => x.Guid == guid);
                    gameTitles = gameTitles + game.EnglishName + ",";
                }
            }
            HttpContext.Session.SetString("GameTitles", gameTitles);
        }
        public async Task<IActionResult> AddGameToWishList(string gameId)
        {
            TempData["CartMessage"] = "";
            Guid guid = new Guid(gameId);
            var wishlist = await _context.Wishlist.Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.PersonId == HttpContext.Session.GetInt32("loggedInPersonID").Value);
            var game = await _context.Game.FirstOrDefaultAsync(x => x.Guid == guid);

            if (wishlist.AddedGameIds.Contains(game.Guid.ToString()))
            {
                TempData["CartMessage"] = "<script>alert('This Game Is Already In Your Wishlist');</script>";
                return RedirectToAction("Index", "Game");
            }
            else
            {
                wishlist.AddedGameIds = wishlist.AddedGameIds + game.Guid.ToString() + ',';

                string provinceCode = wishlist.Person.ProvinceCode;
                var province = await _context.Province.FirstOrDefaultAsync(x => x.Code == provinceCode);
                GuidToGameTitle(wishlist.AddedGameIds, 1);
                TempData["CartMessage"] = "<script>alert('New Item Added In Your Wishlist');</script>";
                try
                {
                    _context.Update(wishlist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistExists(wishlist.WishlistId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = wishlist.WishlistId });
            }
        }
        public async Task<IActionResult> DeleteGameFromWishList(string title)
        {
            string trimmed = ExtractName(title);
            TempData["CartMessage"] = "";
            var game = await _context.Game.FirstOrDefaultAsync(x => x.EnglishName == trimmed);
            var wishlist = await _context.Wishlist.Include(x => x.Person).FirstOrDefaultAsync(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID"));
            string guid = game.Guid.ToString().Trim();
            wishlist.AddedGameIds = wishlist.AddedGameIds.Replace(guid + ",", "");
            TempData["CartMessage"] = "<script>alert('Game Has Removed From Your wishlist');</script>";
            try
            {
                _context.Update(wishlist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(wishlist.WishlistId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = wishlist.WishlistId });
        }
        public async Task<IActionResult> WishlistToCart(string title)
        {

            string newTitle = ExtractName(title);
            var game = await _context.Game.FirstOrDefaultAsync(x => x.EnglishName == newTitle);
            string guid = game.Guid.ToString().ToLower().Trim();

            var wishlist = await _context.Wishlist.FirstOrDefaultAsync(x => x.WishlistId == HttpContext.Session.GetInt32("loggedInPersonID"));
            var cart = await _context.Cart.FirstOrDefaultAsync(x => x.CartId == HttpContext.Session.GetInt32("loggedInPersonID"));
            if(cart == null)
            {
                cart = new Cart();
                cart.CartId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
                cart.PersonId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
                cart.AddedGameIds = "";
                cart.Tax = 0;
                cart.Total = 0;
                _context.Add(cart);
            }
            wishlist.AddedGameIds = wishlist.AddedGameIds.Replace(guid + ",", "");
            cart.AddedGameIds += guid + ",";
            await _context.SaveChangesAsync();
            TempData["CartMessage"] = "<script>alert('Game has been added to your cart from your wishlist!');</script>";
            return RedirectToAction(nameof(Details), new { id = HttpContext.Session.GetInt32("loggedInPersonID") });
        }

        // GET: Wishlists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(id == HttpContext.Session.GetInt32("loggedInPersonID").Value)
            {
                var wishlist = await _context.Wishlist
                    .Include(w => w.Person)
                    .FirstOrDefaultAsync(m => m.WishlistId == id);
                if (wishlist == null)
                {
                    Wishlist tmpWishlist = new Wishlist();
                    tmpWishlist.WishlistId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
                    tmpWishlist.PersonId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
                    tmpWishlist.AddedGameIds = "";
                    _context.Add(tmpWishlist);
                    await _context.SaveChangesAsync();
                    wishlist = await _context.Wishlist
                     .Include(w => w.Person)
                     .FirstOrDefaultAsync(m => m.WishlistId == id);
                }
                GuidToGameTitle(wishlist.AddedGameIds, 1);
                ViewBag.GameTitles = HttpContext.Session.GetString("GameTitles");
                return View(wishlist);
            }
            else
            {
                return NotFound();
            }
        }

        private bool WishlistExists(int id)
        {
            return _context.Wishlist.Any(e => e.WishlistId == id);
        }
    }
}
