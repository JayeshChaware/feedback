using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Feedback_DAL.Data;
using Feedback_DAL.Models;
using Feedback_Service.Interface;
using Feedback_DAL.ViewModels;

namespace Feedback.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        public ProductsController(IProduct context)
        {
            _product = context;
        }

        // GET: Products
        public IActionResult Index(string search, string sortOrder, string delete)
        {
            List<Product> result = _product.GetAllProduct().ToList();

            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (sortOrder == "Date")
            {
                result = result.OrderByDescending(x => x.Id).ToList();
            }

            if (search != null)
            {
                result = result.Where(x => x.Name.Contains(search)).ToList();
            }

            if (delete != null)
            {
                int deleteid = Convert.ToInt32(delete);
                DeleteConfirmed(deleteid);
            }
            List<Product> newresult = _product.GetAllProduct().ToList();
            
            return View(newresult);
        }

            // GET: Products/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                _product.AddProduct(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _product.UpdateProduct(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _product.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
             _product.DeleteProductById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _product.Any(id);
        }
    }
}
