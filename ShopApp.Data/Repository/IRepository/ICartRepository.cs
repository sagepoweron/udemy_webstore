using ShopApp.DataAccess.Models;

namespace ShopApp.DataAccess.Repository.IRepository
{
    public interface ICartRepository : IRepository<Cart>
	{
		void Update(Cart obj);
	}
}
