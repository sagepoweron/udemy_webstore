using System.Linq.Expressions;

namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class
	{
		//IEnumerable<T> GetAll();
		//void Update(T entity);

		void Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		
		bool Exists(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll(string? include_properties = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> expression, string? include_properties = null);
        Task<IEnumerable<T>> GetAllAsync(string? include_properties = null);
    }
}
