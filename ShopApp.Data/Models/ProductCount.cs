using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.DataAccess.Models
{
    public class ProductCount
    {
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
		public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        [Range(0, 100, ErrorMessage = "Limit of 100")]
        public int Count { get; set; }



		[ForeignKey(nameof(CartId))]
		[ValidateNever]
		public Cart Cart { get; set; }

        [ForeignKey(nameof(ProductId))]
        [ValidateNever]
        public Product Product { get; set; }

        

        
    }
}
