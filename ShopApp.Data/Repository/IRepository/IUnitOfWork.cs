namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository CategoryRepository { get; }
		IProductRepository ProductRepository { get; }
		ICartItemRepository ShoppingCartRepository { get; }
		IApplicationUserRepository ApplicationUserRepository { get; }

		Task SaveAsync();
	}
}
