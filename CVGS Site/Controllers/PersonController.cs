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
using System.Net;

namespace CVGS_Site.Controllers
{
    public class PersonController : Controller
    {
        private readonly CVGSContext _context;

        public PersonController(CVGSContext context)
        {
            _context = context;
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
        // GET: Person
        public async Task<IActionResult> Index()
        {
            dynamic myModel = new ExpandoObject();
            var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == HttpContext.Session.GetInt32("loggedInPersonID"));
            if (person != null)
            {
                var employee = await _context.Employee.FirstOrDefaultAsync(x => x.PersonId == person.Id);
                myModel.Person = person;
                myModel.Employee = employee;
                return View(myModel);
            }
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> Profile(int profileId = 0)
        {
            dynamic myModel = new ExpandoObject();
            var profile = await _context.Person.FirstOrDefaultAsync(x => x.Id == profileId);
            var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == HttpContext.Session.GetInt32("loggedInPersonID"));

            if(person == null)
            {
                TempData["loginToView"] = profileId;
                return RedirectToAction("Login", new { pageCode = "viewProfile" });
            }
            if(profile == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var wishlist = await _context.Wishlist
                    .Include(w => w.Person)
                    .FirstOrDefaultAsync(m => m.WishlistId == profileId);
                if (wishlist == null)
                {
                    Wishlist tmpWishlist = new Wishlist();
                    tmpWishlist.WishlistId = profileId;
                    tmpWishlist.PersonId = profileId;
                    tmpWishlist.AddedGameIds = "";
                    _context.Add(tmpWishlist);
                    await _context.SaveChangesAsync();
                    wishlist = await _context.Wishlist
                     .Include(w => w.Person)
                     .FirstOrDefaultAsync(m => m.WishlistId == profileId);
                }
                GuidToGameTitle(wishlist.AddedGameIds, 1);
                ViewBag.GameTitles = HttpContext.Session.GetString("GameTitles");
                myModel.Person = person;
                myModel.Profile = profile;
                myModel.Wishlist = wishlist;
                return View(myModel);
            }
        }
        public async Task<IActionResult> Login(string userName = "", string password = "", string pageCode = "")
        {
            int loginAttemptDuration = 2;
            if (!HttpContext.Session.GetInt32("LoginAttempts").HasValue)
            {
                HttpContext.Session.SetInt32("LoginAttempts", 0);
            }
            if(HttpContext.Session.GetInt32("LoginAttempts") < 5)
            {
                if (HttpContext.Session.GetString("FirstLoginTime") != null && DateTime.Now - DateTime.Parse(HttpContext.Session.GetString("FirstLoginTime")) > TimeSpan.FromMinutes(loginAttemptDuration))
                {
                    HttpContext.Session.SetInt32("LoginAttempts", 0);
                }
                string userNameTrim = "";
                string passwordTrim = "";
                var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == HttpContext.Session.GetInt32("loggedInPersonID"));
                TempData["userName"] = userNameTrim;
                if (person != null)
                {
                    HttpContext.Session.SetInt32("LoginAttempts", 0);
                    return View("Index", person);
                }
                if (userName != null)
                {
                    userNameTrim = userName.Trim();
                }
                if (password != null)
                {
                    passwordTrim = password.Trim();
                }
                if (userName != null && userNameTrim != "")
                {
                    person = await _context.Person.FirstOrDefaultAsync(x => x.UserName == userNameTrim);
                    string recaptchaResponse = this.Request.Form["g-recaptcha-response"];
                    if (!ReCaptchaPassed(recaptchaResponse))
                    {
                        TempData["LoginError"] = "You failed the CAPTCHA.";

                    }
                    else
                    {
                        if (person == null)
                        {
                            TempData["LoginError"] = "Failed to find: " + userNameTrim;
                        }
                        else if (person.Password == passwordTrim)
                        {
                            HttpContext.Session.SetInt32("loggedInPersonID", person.Id);
                            if (pageCode == "viewProfile")
                            {
                                HttpContext.Session.SetInt32("LoginAttempts", 0);
                                return RedirectToAction("Profile", new { profileId = TempData["loginToView"] });
                            }
                            HttpContext.Session.SetInt32("LoginAttempts", 0);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["LoginError"] = "Wrong Password";
                        }
                    }
                }
                else
                {
                    TempData["LoginError"] = "Empty username";
                }
                if (pageCode == "")
                {
                    TempData["LoginError"] = "";
                }
                else if (pageCode == "viewProfile")
                {
                    TempData["LoginError"] = "Login to view profile.";
                }
                if(HttpContext.Session.GetInt32("LoginAttempts").Value == 0)
                {
                    HttpContext.Session.SetString("FirstLoginTime", DateTime.Now.ToString());
                }
                if(TempData["LoginError"].ToString() != "")
                {
                    HttpContext.Session.SetInt32("LoginAttempts", HttpContext.Session.GetInt32("LoginAttempts").Value + 1);
                    TempData["LoginError"] = TempData["LoginError"] + " (" + (5 - HttpContext.Session.GetInt32("LoginAttempts").Value) + ") login attemps left.";
                }
                return View("Login");
            }

            TempData["LoginError"] = "Too Many Failed Login Attempts.";
            if (HttpContext.Session.GetString("FirstLoginTime") != null && DateTime.Now - DateTime.Parse(HttpContext.Session.GetString("FirstLoginTime")) > TimeSpan.FromMinutes(loginAttemptDuration))
            {
                TempData["LoginError"] = "Login Attempts has reset.";
                HttpContext.Session.SetInt32("LoginAttempts", 0);
            }

            return View("Login");
        }
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.SetInt32("loggedInPersonID", 0);
            return RedirectToAction("Login");
        }
        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = await _context.Person
                .Include(p => p.CountryCodeNavigation)
                .Include(p => p.ProvinceCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            ViewData["CountryCode"] = new SelectList(_context.Country, "Code", "Code");
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "Code", "Code");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Surname,GivenName,Street,City,ProvinceCode,CountryCode,PostalCode,LandLine,Extension,Mobile,Fax,Email,UserName,Password")] Person person, string? Password = "somebody")
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetInt32("loggedInPersonID", (await _context.Person.FirstOrDefaultAsync(x => x.UserName == person.UserName)).Id);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryCode"] = new SelectList(_context.Country, "Code", "Code", person.CountryCode);
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "Code", "Code", person.ProvinceCode);
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit()
        {
            dynamic myModel = new ExpandoObject();
            var person = await _context.Person.FirstOrDefaultAsync(x => x.Id == HttpContext.Session.GetInt32("loggedInPersonID"));
            if (person == null)
            {
                return RedirectToAction("Login");
            }
            ViewData["CountryCode"] = new SelectList(_context.Country, "Code", "Code", person.CountryCode);
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "Code", "Code", person.ProvinceCode);
            myModel.Person = person;
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Surname,GivenName,Street,City,ProvinceCode,CountryCode,PostalCode,LandLine,Extension,Mobile,Fax,Email,UserName,Password")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }
            if(id == HttpContext.Session.GetInt32("loggedInPersonID"))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(person);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!PersonExists(person.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction("Profile", new { profileId = id });
                }
            }
            else
            {
                TempData["EditError"] = "You don't have permission to edit this profile.";
            }
            ViewData["CountryCode"] = new SelectList(_context.Country, "Code", "Code", person.CountryCode);
            ViewData["ProvinceCode"] = new SelectList(_context.Province, "Code", "Code", person.ProvinceCode);
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Person
                .Include(p => p.CountryCodeNavigation)
                .Include(p => p.ProvinceCodeNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
        public bool ReCaptchaPassed(string gRecaptchaResponse)
        {

            using (var webclient = new WebClient())
            {
                string validateString = "https://www.google.com/recaptcha/api/siteverify?secret=" + "6LdisQEdAAAAAF3f8d3eNhDJ0tTzRxZzz4r1bx1d" + "&response=" + gRecaptchaResponse;
                var recaptcha_result = webclient.DownloadString(validateString);
                if (recaptcha_result.ToLower().Contains("false"))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
