﻿using ShopApp.DataAccess.Data;
using ShopApp.DataAccess.Models;
using ShopApp.DataAccess.Repository.IRepository;

namespace ShopApp.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
	{
		private readonly ApplicationDbContext _context;

		public ApplicationUserRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}