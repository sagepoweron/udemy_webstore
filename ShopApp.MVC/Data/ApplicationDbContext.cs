using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApp.MVC.Models;
using System.Numerics;
using ShopApp.MVC.Models.Products;

namespace ShopApp.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; } = default!;
		public DbSet<VideoGame> VideoGame { get; set; } = default!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			Category category1 = new()
			{
				//Id = Guid.NewGuid(),
				Id = 1,
				Name = "Movies",
				DisplayOrder = 1
			};

			Category category2 = new()
			{
				//Id = Guid.NewGuid(),
				Id= 2,
				Name = "Videogames",
				DisplayOrder = 2
			};

			modelBuilder.Entity<Category>().HasData(category1, category2);

			VideoGame videogame1 = new()
			{
				Id = Guid.NewGuid(),
				Name = "Test Game",
				ListPrice = 50
			};

			modelBuilder.Entity<VideoGame>().HasData(videogame1);

			base.OnModelCreating(modelBuilder);
		}
        

    }
}
