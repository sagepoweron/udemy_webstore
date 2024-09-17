using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.MVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CartController(IUnitOfWork context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //video 133
        public async Task<IActionResult> Details(Guid id)
        {
            CartItem cart_item = new()
            {
                Product = await _context.ProductRepository.GetAsync(expression: m => m.Id == id, include_properties: "Category"),
                Count = 1,
                ProductId = id
            };

            //    var product = await _context.Product
            //        .Include(p => p.Category)
            //        .FirstOrDefaultAsync(m => m.Id == id);

            return View(cart_item);
        }
    }
}
