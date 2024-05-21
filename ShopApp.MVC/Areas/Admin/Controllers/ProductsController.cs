using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IUnitOfWork context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Products
        //public async Task<IActionResult> Index()
        //{
        //    var shopAppMVCContext = _context.Product.Include(p => p.Category);
        //    return View(await shopAppMVCContext.ToListAsync());
        //}
        public async Task<IActionResult> Index()
        {
            var query = _context.ProductRepository.GetAllAsync(include_properties:"Category");
            return View(await query);
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //    var product = await _context.Product
            //        .Include(p => p.Category)
            //        .FirstOrDefaultAsync(m => m.Id == id);
            var product = await _context.ProductRepository.GetAsync(expression: m => m.Id == id, include_properties: "Category");
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        // GET: Admin/Products/Create
        //public IActionResult Create()
        //{
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name");
        //    return View();
        //}
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.CategoryRepository.GetAll(), "Id", "Name");
            return View();
        }


        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Description,ListPrice,SalePrice,ImageUrl")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        product.Id = Guid.NewGuid();
        //        _context.Add(product);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", product.CategoryId);
        //    return View(product);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryId,Name,Description,ListPrice,SalePrice,ImageUrl")] Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    //string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    string filename = Path.ChangeExtension(Path.GetRandomFileName(), extension);
                    string product_path = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(product.ImageUrl))
                    {
                        //string old_image_path = Path.Combine(product_path, product.ImageUrl.TrimStart('\\'));
                        //string old_image_path = Path.GetFileName(product.ImageUrl);
                        string old_image_path = Path.Combine(product_path, Path.GetFileName(product.ImageUrl));

                        if (System.IO.File.Exists(old_image_path))
                        {
                            System.IO.File.Delete(old_image_path);
                        }
                    }

                    using (var file_stream = new FileStream(Path.Combine(product_path, filename), FileMode.Create))
                    {
                        file.CopyTo(file_stream);
                    }

                    product.ImageUrl = @"\images\product\" + filename;
                }


                product.Id = Guid.NewGuid();

                //_context.Add(product);
                //await _context.SaveChangesAsync();
                _context.ProductRepository.Add(product);
                await _context.SaveAsync();

                return RedirectToAction(nameof(Index));
            }

            //ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", product.CategoryId);
            ViewData["CategoryId"] = new SelectList(_context.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);

            return View(product);
        }


        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.ProductRepository.GetAsync(expression: m => m.Id == id);
            //var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", product.CategoryId);
            ViewData["CategoryId"] = new SelectList(_context.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CategoryId,Name,Description,ListPrice,SalePrice,ImageUrl")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(product);
                    //await _context.SaveChangesAsync();
                    _context.ProductRepository.Update(product);
                    await _context.SaveAsync();
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
            //ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "Name", product.CategoryId);
            ViewData["CategoryId"] = new SelectList(_context.CategoryRepository.GetAll(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var product = await _context.Product
            //    .Include(p => p.Category)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var product = await _context.ProductRepository.GetAsync(expression: m => m.Id == id, include_properties: "Category");
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //var product = await _context.Product.FindAsync(id);
            var product = await _context.ProductRepository.GetAsync(expression: m => m.Id == id);
            if (product != null)
            {
                //_context.Product.Remove(product);
                _context.ProductRepository.Remove(product);
            }

            //await _context.SaveChangesAsync();
            await _context.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(Guid id)
        {
            return _context.ProductRepository.Exists(expression: m => m.Id == id);
            //return _context.Product.Any(e => e.Id == id);
        }
    }
}
