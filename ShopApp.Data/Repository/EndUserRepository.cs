using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
    public class EndUserRepository : Repository<EndUser>, IEndUserRepository
	{
		private readonly ApplicationDbContext _context;

		public EndUserRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
