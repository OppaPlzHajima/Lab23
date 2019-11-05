using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab23.Models;

namespace Lab23.Controllers
{

    public class LoginController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users u)
        {
            if (db.Users.Contains(u))
            {
                ViewBag.Error = "That user already exists";
                return View();
            }
            else
            {
                db.Users.Add(u);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Login()
        {
            return View();
        }
        ShopContext db = new ShopContext();


        [HttpPost]
        public IActionResult Login(string Name, string Password)
        {
            List<Users> users = db.Users.ToList();

            for (int i = 0; i < users.Count; i++)
            {
                Users u = users[i];
                if (u.UserName == Name && u.Password == Password)
                {
                    //Log in the user
                    TempData["User"] = u;
                }
            }

            ViewBag.Error = "Incorrect password / username, please register or try again";
            return RedirectToAction("Index", "Home");
        }

    }
}



//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.Users.ToListAsync());
//        }

//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var users = await _context.Users
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (users == null)
//            {
//                return NotFound();
//            }

//            return View(users);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//       [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,UserName,Password,Funds")] Users users)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(users);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(users);
//        }

//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var users = await _context.Users.FindAsync(id);
//            if (users == null)
//            {
//                return NotFound();
//            }
//            return View(users);
//        }

//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password,Funds")] Users users)
//        {
//            if (id != users.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(users);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!UsersExists(users.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(users);
//        }

//        // GET: Login/Delete/5
//        public async Task<IActionResult> Delete(int id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var users = await _context.Users
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (users == null)
//            {
//                return NotFound();
//            }

//            return View(users);
//        }

//        // POST: Login/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]


//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var users = await _context.Users.FindAsync(id);
//            _context.Users.Remove(users);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool UsersExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }

//        [HttpPost]
//        public IActionResult Register(Users u)
//        {
//            if (db.Users.Contains(u))
//            {
//                ViewBag.Error = "That user already exists";
//                return View();
//            }
//            else
//            {
//                db.Users.Add(u);
//                db.SaveChanges();

//                return RedirectToAction("Index", "Home");
//            }

//            public IActionResult Login()
//            {
//                return View();
//            }
//            ShopContext db = new ShopContext();

//        }
//        [HttpPost]
//        public IActionResult Login(string Name, string Password)
//        {
//            List<Users> users = db.Users.ToList();

//            for (int i = 0; i < users.Count; i++)
//            {
//                Users u = users[i];
//                if (u.UserName == Name && u.Password == Password)
//                {
//                    //Log in the user
//                    TempData["User"] = u;
//                }
//            }

//            ViewBag.Error = "Incorrect User name or password, please register or try again";
//            return RedirectToAction("Index", "Home");
//        }
//    }
//}


