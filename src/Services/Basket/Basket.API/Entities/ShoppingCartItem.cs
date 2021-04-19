using System.ComponentModel.DataAnnotations;

namespace Basket.API.Entities
{
    public class ShoppingCartItem
    {
        [Required]
        [Range(1,100)]
        public int Quantity { get; set; }
        
        public string Color { get; set; }
        
        public decimal Price { get; set; }
        
        [Required]
        public string ProductId { get; set; }

        public string ProductName { get; set; }

    }
}