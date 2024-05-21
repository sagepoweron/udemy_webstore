namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository CategoryRepository { get; }
		IProductRepository ProductRepository { get; }
		Task SaveAsync();
	}
}
