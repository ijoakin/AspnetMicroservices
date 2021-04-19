using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
            
        public ShoppingCart()
        {

        }

        public ShoppingCart(string userName)
        {
            UserName = userName; 
        }

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Price;
                }
                return total;
            }
        }

        public decimal TotalPriceBetter
        {
            get
            {
                return Items.Sum(x => x.Price);
            }
        }

        public decimal TotalPriceParallel
        {
            get
            {
                decimal number = 0;
                Parallel.ForEach(Items, item =>
                {
                    number += item.Price;
                });
                return number;
            }
        }
    }
}
