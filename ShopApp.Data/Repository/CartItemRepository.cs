using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
	{
		private readonly ApplicationDbContext _context;

        public CartItemRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(CartItem item)
		{
			_context.Update(item);
		}
    }
}
