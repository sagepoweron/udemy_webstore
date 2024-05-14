using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.DataAccess.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category? Category { get; set; }

        [Required]
        public string Name { get; set; } = "Default";
        public string? Description { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(0, 1000)]
        public double ListPrice { get; set; }

        [Display(Name = "Sale Price")]
        [Range(0, 1000)]
        public double SalePrice { get; set; }

        public string? ImageUrl { get; set; }
    }
}
