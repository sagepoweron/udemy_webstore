using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Models;

namespace ShopApp.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; } = default!;
		public DbSet<Product> Product { get; set; } = default!;
		//public DbSet<ApplicationUser> ApplicationUser { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			Category category1 = new()
			{
				Id = Guid.NewGuid(),
				Name = "Movies",
				DisplayOrder = 1
			};

			Category category2 = new()
			{
				Id = Guid.NewGuid(),
				Name = "Videogames",
				DisplayOrder = 2
			};

			modelBuilder.Entity<Category>().HasData(category1, category2);

			Product product1 = new()
			{
				Id = Guid.NewGuid(),
				Name = "Test Game",
				CategoryId = category2.Id,
				ListPrice = 60,
				SalePrice = 50
			};

			modelBuilder.Entity<Product>().HasData(product1);

			base.OnModelCreating(modelBuilder);
		}
	}
}
