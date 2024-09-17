using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Models.ViewModels
{
    public class CartVM
    {
        public IEnumerable<CartItem>? CartItems { get; set; }
        public int OrderTotal { get; set; }
    }
}
