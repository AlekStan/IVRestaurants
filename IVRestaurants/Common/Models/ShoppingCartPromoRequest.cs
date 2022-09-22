using Domain.Models;

namespace IVRestaurants.Models
{
    public class ShoppingCartPromoRequest
    {
        public ShoppingCartDTO ShoppingCart { get; set; }

        public MenuPromoDTO MenuPromo { get; set; }
    }
}
