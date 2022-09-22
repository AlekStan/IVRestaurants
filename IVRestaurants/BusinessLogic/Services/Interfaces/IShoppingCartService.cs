using Domain.Models;

namespace BusinessLogic.Services.Interfaces
{
    public interface IShoppingCartService
    {
        public ShoppingCartDTO AddMenuItem(ShoppingCartDTO shoppingCart, MenuItemDTO menuItem);
        public ShoppingCartDTO RemoveMenuItem(ShoppingCartDTO shoppingCart, MenuItemDTO menuItem);
        public ShoppingCartDTO AddMenuPromo(ShoppingCartDTO shoppingCart, MenuPromoDTO menuPromo);
        public ShoppingCartDTO RemoveMenuPromo(ShoppingCartDTO shoppingCart, MenuPromoDTO menuPromo);
    }
}
