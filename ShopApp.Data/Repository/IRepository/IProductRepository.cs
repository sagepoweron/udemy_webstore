using ShopApp.DataAccess.Models;

namespace ShopApp.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
	{
		void Update(Product product);
	}
}
