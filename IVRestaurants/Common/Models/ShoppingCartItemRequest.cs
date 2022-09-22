using Domain.Models;

namespace IVRestaurants.Models
{
    public class ShoppingCartItemRequest
    {
        public ShoppingCartDTO ShoppingCart { get; set; }

        public MenuItemDTO MenuItem { get; set; }
    }
}
