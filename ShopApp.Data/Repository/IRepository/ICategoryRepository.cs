using ShopApp.DataAccess.Models;

namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category category);
	}
}
