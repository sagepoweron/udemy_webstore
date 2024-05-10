using System.Linq.Expressions;

namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T?> GetAsync(Expression<Func<T, bool>> expression);
		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		//void Update(T entity);
		bool Exists(Expression<Func<T, bool>> expression);
	}
}
