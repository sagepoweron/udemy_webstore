using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Other;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = Helpers.Admin_Role)] //video 120
	public class CategoriesController : Controller
	{
		private readonly IUnitOfWork _context;
		public CategoriesController(IUnitOfWork context)
		{
			_context = context;
		}

		// GET: Admin/Categories
		public async Task<IActionResult> Index()
		{
			return View(await _context.CategoryRepository.GetAllAsync());
		}


		// GET: Admin/Categories/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.CategoryRepository.GetAsync(m => m.Id == id);
			//var category = await _context.Category
			//    .FirstOrDefaultAsync(m => m.Id == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// GET: Admin/Categories/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Categories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,DisplayOrder")] Category category)
		{
			if (ModelState.IsValid)
			{
				category.Id = Guid.NewGuid();

				_context.CategoryRepository.Add(category);
				await _context.SaveAsync();
				//_context.Add(category);
				//await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(category);
		}

		// GET: Admin/Categories/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.CategoryRepository.GetAsync(m => m.Id == id);
			//var category = await _context.Category.FindAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return View(category);
		}

		// POST: Admin/Categories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,DisplayOrder")] Category category)
		{
			if (id != category.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.CategoryRepository.Update(category);
					await _context.SaveAsync();

					//_context.Update(category);
					//await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoryExists(category.Id))
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
			return View(category);
		}

		// GET: Admin/Categories/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var category = await _context.CategoryRepository.GetAsync(m => m.Id == id);
			//var category = await _context.Category
			//    .FirstOrDefaultAsync(m => m.Id == id);
			if (category == null)
			{
				return NotFound();
			}

			return View(category);
		}

		// POST: Admin/Categories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var category = await _context.CategoryRepository.GetAsync(m => m.Id == id);
			//var category = await _context.Category.FindAsync(id);
			if (category != null)
			{
				_context.CategoryRepository.Remove(category);
				//_context.Category.Remove(category);
			}

			await _context.SaveAsync();
			//await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CategoryExists(Guid id)
		{
			return _context.CategoryRepository.Exists(m => m.Id == id);
			//return _context.Category.Any(e => e.Id == id);
		}
	}
}
