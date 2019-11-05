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
    public class ShopController : Controller
    {
        private readonly ShopContext _context;

        public ShopController(ShopContext context)
        {
            _context = context;
        }


        ShopContext db = new ShopContext();
        // GET: Shop
        public IActionResult Index()
        {
            List<Products> products = db.Products.ToList();
            return View(db.Products.ToList());
        }

        public IActionResult Buy(int id)
        {
            Products p = db.Products.Find(id);
            if (p != null)
            {
                return View(p);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
        }


    }
}

        // GET: Shop/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var products = await _context.Products
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (products == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(products);
        //}

//        // GET: Shop/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: Shop/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Products products)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(products);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(products);
//        }

//        // GET: Shop/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var products = await _context.Products.FindAsync(id);
//            if (products == null)
//            {
//                return NotFound();
//            }
//            return View(products);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Products products)
//        {
//            if (id != products.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(products);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ProductsExists(products.Id))
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
//            return View(products);
//        }

//        // GET: Shop/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var products = await _context.Products
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (products == null)
//            {
//                return NotFound();
//            }

//            return View(products);
//        }



//        public IActionResult Buy(int id)
//        {
//            Products p = db.Products.Find(id);
//            if (p != null)
//            {
//                return View(p);
//            }
//            else
//            {

//                return RedirectToAction("Index", "Product");
//            }
//        }
//            public IActionResult Receipt(Products p)
//            {

//            ViewBag.Name= p.Name;
//            return View();
//            }

        
//        // POST: Shop/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var products = await _context.Products.FindAsync(id);
//            _context.Products.Remove(products);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool ProductsExists(int id)
//        {
//            return _context.Products.Any(e => e.Id == id);
//        }


//    }
//}
