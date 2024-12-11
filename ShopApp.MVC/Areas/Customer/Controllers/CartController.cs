using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

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

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
			var query = _context.CartRepository.GetAllAsync();
			return View(await query);
        }

        public IActionResult AddProduct(Guid id)
        {
            Product product = _context.ProductRepository.Get(x => x.Id == id);

            AddProductToCart(product);

            return View();
        }







        public void AddProductToCart(Product product)
        {
            if (User.Identity == null || product == null)
            {
                return;
            }

            IdentityUser user = _context.CartRepository.Context.Users.Where(user => user.UserName == User.Identity.Name).FirstOrDefault();

            //EndUser user = _context.EndUserRepository.Get(user => user.UserName == User.Identity.Name);

            if (user == null)
            {
                return;
            }

            Cart cart = _context.CartRepository.Get(cart => cart.UserId == user.Id);
            if (cart == null)
            {
                cart = new()
                {
                    UserId = user.Id,
                };
                _context.CartRepository.Add(cart);
                _context.CartRepository.Context.SaveChanges();
            }

            ProductCount product_count = new()
            {
                Product = product,
                Count = 1
            };
            cart.ProductCounts.Add(product_count);
            
        }
	}
}
