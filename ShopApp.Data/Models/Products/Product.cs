using System.ComponentModel.DataAnnotations;

namespace ShopApp.DataAccess.Models.Products
{
    public abstract class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = "Default";
        public string? Description { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(0, 1000)]
        public double ListPrice { get; set; }

        //[Display(Name = "Discount Price")]
        //[Range(0, 1000)]
        //public double DiscountPrice { get; set; }

        //public string? ImageUrl { get; set; }
    }
}
