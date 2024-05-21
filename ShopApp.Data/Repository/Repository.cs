using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;
using System.Linq;
using System.Linq.Expressions;

namespace ShopApp.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}

		public void Add(T entity)
		{
			_dbSet.Add(entity);
		}

		public async Task<T?> GetAsync(Expression<Func<T, bool>> expression)
		{
			IQueryable<T> query = _dbSet.Where(expression);
			return await query.FirstOrDefaultAsync();
		}

		public IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}
		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await _dbSet.ToListAsync();
		}

		public void Remove(T entity)
		{
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entities)
		{
			_dbSet.RemoveRange(entities);
		}

		public bool Exists(Expression<Func<T, bool>> expression)
		{
			return _dbSet.Any(expression);
		}
	}
}
