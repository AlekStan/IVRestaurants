using Domain.Models;

namespace Common.Models
{
    public class ShoppingCartItemRequest
    {
        public ShoppingCartDTO ShoppingCart { get; set; }

        public MenuItemDTO MenuItem { get; set; }
    }
}
