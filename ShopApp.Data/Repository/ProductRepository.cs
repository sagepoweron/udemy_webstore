using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Product product)
		{
			_context.Update(product);
		}
    }
}
