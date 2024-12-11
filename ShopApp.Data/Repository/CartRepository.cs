using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
    public class CartRepository : Repository<Cart>, ICartRepository
	{
		private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Cart obj)
		{
			_context.Update(obj);
		}
    }
}
