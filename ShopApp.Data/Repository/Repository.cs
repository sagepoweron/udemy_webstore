using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Repository.IRepository;
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
            _context.Product.Include(u => u.Category);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T? Get(Expression<Func<T, bool>> expression, string? include_properties = null)
        {
            IQueryable<T> query = _dbSet.Where(expression);

            if (!string.IsNullOrEmpty(include_properties))
            {
                foreach (var include_property in include_properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(include_property);
                }
            }

            return query.FirstOrDefault();
        }
        public IEnumerable<T> GetAll(string? include_properties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrEmpty(include_properties))
            {
                foreach (var include_property in include_properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include_property);
                }
            }

            return query.ToList();
        }



        public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, string? include_properties = null)
        {
            IQueryable<T> query = _dbSet.Where(expression);

            if (!string.IsNullOrEmpty(include_properties))
            {
                foreach (var include_property in include_properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include_property);
                }
            }

            return await query.FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<T>> GetAllAsync(string? include_properties = null)
        {
            IQueryable<T> query = _dbSet;
            if (!string.IsNullOrEmpty(include_properties))
            {
                foreach (var include_property in include_properties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(include_property);
                }
            }

            return await query.ToListAsync();
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
