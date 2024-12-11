using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        public ICartRepository CartRepository { get; private set; }
        public IEndUserRepository EndUserRepository { get; private set; }


        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context);
            CartRepository = new CartRepository(_context);
            //EndUserRepository = new EndUserRepository(_context);
        }

        //public Task SaveAsync()
        //{
        //	return _context.SaveChangesAsync();
        //}

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
