using Domain.Models;

namespace Common.Models
{
    public class ShoppingCartPromoRequest
    {
        public ShoppingCartDTO ShoppingCart { get; set; }

        public MenuPromoDTO MenuPromo { get; set; }
    }
}
