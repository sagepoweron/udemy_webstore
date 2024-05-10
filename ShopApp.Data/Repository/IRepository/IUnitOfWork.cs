namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository CategoryRepository { get; }
		Task SaveAsync();
	}
}
