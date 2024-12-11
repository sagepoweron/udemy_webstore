﻿namespace ShopApp.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository CategoryRepository { get; }
		IProductRepository ProductRepository { get; }
		ICartRepository CartRepository { get; }
		IEndUserRepository EndUserRepository { get; }

		Task SaveAsync();
	}
}
