using ShopApp.DataAccess.Models;

namespace ShopApp.DataAccess.Repository.IRepository
{
    public interface ICartItemRepository : IRepository<CartItem>
	{
		void Update(CartItem shoppingcart);
	}
}
