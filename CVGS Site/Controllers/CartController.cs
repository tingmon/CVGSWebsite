using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CVGS_Site.Models;
using Microsoft.AspNetCore.Http;



namespace CVGS_Site.Controllers
{
    public class CartController : Controller
    {
        private readonly CVGSContext _context;

        public CartController(CVGSContext context)
        {
            _context = context;
        }

        // Add Game to Cart
        public async Task<IActionResult> AddGameToCart(string gameId)
        {
            TempData["CartMessage"] = "";
            Guid guid = new Guid(gameId);
            var cart = await _context.Cart.Include(c => c.Person)
                .FirstOrDefaultAsync(c => c.PersonId == HttpContext.Session.GetInt32("loggedInPersonID").Value);
            var game = await _context.Game.FirstOrDefaultAsync(x => x.Guid == guid);

            if (cart.AddedGameIds.Contains(game.Guid.ToString()))
            {
                TempData["CartMessage"] = "<script>alert('This Game Is Already In Your Cart');</script>";
                return RedirectToAction("Index", "Game");
            }
            else
            {
                cart.AddedGameIds = cart.AddedGameIds + game.Guid.ToString() + ',';

                string provinceCode = cart.Person.ProvinceCode;
                var province = await _context.Province.FirstOrDefaultAsync(x => x.Code == provinceCode);
                CalculateTaxAndTotal(cart, province, 1);
                GuidToGameTitle(cart.AddedGameIds, 1);
                TempData["CartMessage"] = "<script>alert('New Item Added In Your Cart');</script>";
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.CartId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", new { id = cart.CartId });
            }
        }

        // Calculate Tax and Total Amount, flag = 1 plus, flag = 0 minus
        public void CalculateTaxAndTotal(Cart cart, Province province, int flag)
        {
            float oldTax = (float)cart.Tax;
            float oldTotal = (float)cart.Total;
            float newTax = 0;
            float newTotal = 0;
            float taxResult = 0;
            float totalResult = 0;
            string[] gameIdList = cart.AddedGameIds.Split(',');
            if (gameIdList.Length > 1)
            {
                Guid gameId = new Guid(gameIdList[gameIdList.Length - 2]);
                var game = _context.Game.FirstOrDefault(x => x.Guid == gameId);
                if (game != null)
                {
                    newTax = (float)(game.Price * (province.FederalTax / 100) + game.Price * (province.ProvincialTax / 100));
                    newTotal = (float)(game.Price + newTax);
                }
            }
            else
            {
                oldTax = 0;
                oldTotal = 0;
            }
            if (flag == 1)
            {
                taxResult = oldTax + newTax;
                totalResult = oldTotal + newTotal;
            }
            else if (flag == 0)
            {
                taxResult = oldTax - newTax;
                totalResult = oldTotal - newTotal;
            }
            cart.Tax = taxResult;
            cart.Total = totalResult;
        }

        // Display Game Title Instead of Guid, flag = 1 with price / flag = 0 without price
        public void GuidToGameTitle(string ids, int flag)
        {
            string gameTitles = "";
            double totalPrice = 0;
            string[] guidList = ids.Split(',');
            foreach (var item in guidList)
            {
                if (item != "" && flag == 1)
                {
                    Guid guid = new Guid(item);
                    var game = _context.Game.FirstOrDefault(x => x.Guid == guid);
                    gameTitles = gameTitles + " - " + game.EnglishName + "       - Price: $" + game.Price + ",";
                    totalPrice = (double)(totalPrice + game.Price);
                }
                if (item != "" && flag == 0)
                {
                    Guid guid = new Guid(item);
                    var game = _context.Game.FirstOrDefault(x => x.Guid == guid);
                    gameTitles = gameTitles + game.EnglishName + ",";
                }
            }
            HttpContext.Session.SetString("GameTitles", gameTitles);
            HttpContext.Session.SetString("TotalPrice", totalPrice.ToString("n2"));
        }

        public static string FormatFloat(double f)
        {
            string formatted = f.ToString("n2");
            return formatted;
        }

        public string ExtractName(string title)
        {
            int index = title.IndexOf("- Price:");
            string trimmed = title.Remove(index);
            trimmed = trimmed.Remove(0, 3).Trim();
            return trimmed;
        }

        // Delete Game from Cart
        public async Task<IActionResult> DeleteGameFromCart(string title)
        {
            string trimmed = ExtractName(title);
            TempData["CartMessage"] = "";
            var game = await _context.Game.FirstOrDefaultAsync(x => x.EnglishName == trimmed);
            var cart = await _context.Cart.Include(x => x.Person).FirstOrDefaultAsync(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID"));
            string guid = game.Guid.ToString().Trim();
            cart.AddedGameIds = cart.AddedGameIds.Replace(guid + ",", "");
            string provinceCode = cart.Person.ProvinceCode;
            var province = await _context.Province.FirstOrDefaultAsync(x => x.Code == provinceCode);
            CalculateTaxAndTotal(cart, province, 0);
            TempData["CartMessage"] = "<script>alert('Game Has Removed From Your Cart');</script>";
            try
            {
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartExists(cart.CartId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = cart.CartId });
        }

        // Create cart if it is not exist
        public async Task<IActionResult> AutoCreateCart()
        {
            int cartId = 0;
            var cartList = _context.Cart.ToList();
            foreach (var item in cartList)
            {
                if (item.CartId == HttpContext.Session.GetInt32("loggedInPersonID").Value)
                {
                    cartId = item.CartId;
                }
            }
            if (cartId == 0)
            {
                Cart cart = new Cart();
                cart.CartId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
                cart.PersonId = HttpContext.Session.GetInt32("loggedInPersonID").Value;
                cart.AddedGameIds = "";
                cart.Tax = 0;
                cart.Total = 0;
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = cart.CartId });
            }
            return RedirectToAction("Details", new { id = cartId });
        }

        // Get Payment info
        public async Task<IActionResult> Pay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var cart = await _context.Cart
                .Include(c => c.Person)
                .FirstOrDefaultAsync(x => x.CartId == id);
            var creditCardRecord = await _context.CreditCardRecord
                .Include(c => c.Person)
                .Where(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID")).ToListAsync();
            if (creditCardRecord.Count == 0)
            {
                TempData["NoCardMessage"] = "<script>alert('Register Credit Card First Before Pay');</script>";
                return RedirectToAction("Index", "CreditCardRecord");
                //return RedirectToAction("Details", new { id = cart.CartId });
            }
            if (cart == null)
            {
                return NotFound();
            }
            ViewBag.BillingAddress = cart.Person.Street + ", " + cart.Person.City + ", " + cart.Person.ProvinceCode + ", " + cart.Person.PostalCode;
            GuidToGameTitle(cart.AddedGameIds, 1);
            ViewBag.GameTitles = HttpContext.Session.GetString("GameTitles");
            ViewBag.TotalPrice = HttpContext.Session.GetString("TotalPrice");
            //ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", cart.PersonId);
            ViewData["CardNumber"] = new SelectList(creditCardRecord, "CardNumber", "CardNumber");
            return View(cart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(string cardNumber)
        {
            var cart = await _context.Cart.Include(x => x.Person).FirstOrDefaultAsync(x => x.PersonId == HttpContext.Session.GetInt32("loggedInPersonID"));
            Guid recordId = Guid.NewGuid();
            //string recordId = guid.ToString();
            int personId = cart.PersonId;
            string gameIds = cart.AddedGameIds;
            GuidToGameTitle(gameIds, 0);
            string productList = HttpContext.Session.GetString("GameTitles");
            string creditCard = cardNumber;
            double amount = (double)cart.Total;
            string formattedAmount = amount.ToString("n2");
            SalesRecord salesRecord = new SalesRecord();
            salesRecord.RecordId = recordId;
            salesRecord.PersonId = personId;
            salesRecord.ProductList = productList;
            salesRecord.CreditCard = creditCard;
            salesRecord.PaymentDate = DateTime.Now;
            salesRecord.Amount = formattedAmount;
            cart.AddedGameIds = "";
            cart.Tax = 0;
            cart.Total = 0;
            _context.Update(cart);
            _context.Add(salesRecord);
            await _context.SaveChangesAsync();

            //var game = _context.Game.FirstOrDefault(x => x.Guid == recordId);
            //game.Guid = recordId;
            return View("DownloadGame", salesRecord);
            //return View(salesRecord);
        }

        public ActionResult MakeReceipt(Guid id)
        {
            TempData["PayMessage"] = "";
            string fileName = @"C:\" + id.ToString() + ".txt";
            var salesRecord = _context.SalesRecord.Include(x => x.Person).FirstOrDefault(x => x.RecordId == id);

            try
            {
                // Check if file already exists. If yes, delete it.     
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }

                // Create a new file     
                using (StreamWriter sw = System.IO.File.CreateText(fileName))
                {
                    sw.WriteLine("Your Receipt Created At: {0}", DateTime.Now.ToString());
                    sw.WriteLine("Purchase Record ID: " + salesRecord.RecordId.ToString());
                    sw.WriteLine("Customer: " + salesRecord.Person.GivenName + salesRecord.Person.Surname);
                    sw.WriteLine("Purchased Items: " + salesRecord.ProductList);
                    sw.WriteLine("Credit Card Number: " + salesRecord.CreditCard);
                    sw.WriteLine("Payment Date: " + salesRecord.PaymentDate);
                    sw.WriteLine("Payment Date: $" + salesRecord.Amount);
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("Thank You!");
                    sw.WriteLine("-Conestoga Virtual Game Store-");
                }

                // Write file contents on console.     
                using (StreamReader sr = System.IO.File.OpenText(fileName))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
                TempData["PayMessage"] = "<script>alert('Your Receipt Saved In Your C Drive');</script>";
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
            return View("DownloadGame", salesRecord);
        }


        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            TempData["NoCardMessage"] = "";
            TempData["CartMessage"] = "";
            TempData["PayMessage"] = "";
            ViewBag.GameTitles = "";
            ViewBag.TotalPrice = "";
            await AutoCreateCart();
            if (id == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .Include(c => c.Person)
                .FirstOrDefaultAsync(m => m.CartId == id);
            GuidToGameTitle(cart.AddedGameIds, 1);
            if (cart == null)
            {
                return NotFound();
            }
            CalculateTaxAndTotal(cart, await _context.Province.FirstOrDefaultAsync(x => x.Code == cart.Person.ProvinceCode), 1);
            ViewBag.GameTitles = HttpContext.Session.GetString("GameTitles");
            ViewBag.TotalPrice = HttpContext.Session.GetString("TotalPrice");

            return View(cart);
        }
        private bool CartExists(int id)
        {
            return _context.Cart.Any(e => e.CartId == id);
        }
    }
} 
