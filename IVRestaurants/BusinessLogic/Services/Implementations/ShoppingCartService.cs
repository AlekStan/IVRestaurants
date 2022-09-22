using BusinessLogic.Services.Interfaces;
using Common.Exceptions;
using Domain.Models;

namespace BusinessLogic.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IMenuPromoService _menuPromoService;

        public ShoppingCartService(IMenuPromoService menuPromoService)
        {
            _menuPromoService = menuPromoService;
        }

        public ShoppingCartDTO AddMenuItem(ShoppingCartDTO shoppingCart, MenuItemDTO menuItem)
        {
            shoppingCart.MenuItems.Add(menuItem);
            shoppingCart.TotalAmount += menuItem.MenuItemPrice;

            return shoppingCart;
        }

        public ShoppingCartDTO AddMenuPromo(ShoppingCartDTO shoppingCart, MenuPromoDTO menuPromo)
        {
            shoppingCart.MenuPromos.Add(menuPromo);
            var menuPromoPrice = _menuPromoService.CalculateMenuPromoPrice(menuPromo);
            shoppingCart.TotalAmount += menuPromoPrice;

            return shoppingCart;
        }

        public ShoppingCartDTO RemoveMenuItem(ShoppingCartDTO shoppingCart, MenuItemDTO menuItem)
        {
            var menuItemForRemoval = shoppingCart.MenuItems.FirstOrDefault(mi => mi.MenuItemId == menuItem.MenuItemId);
            if (menuItemForRemoval == null) throw new IVRestaurantsBusinessException($"There is no {menuItem.MenuItemName} menu item in the shopping cart!");

            shoppingCart.MenuItems.Remove(menuItemForRemoval);
            shoppingCart.TotalAmount -= menuItem.MenuItemPrice;

            return shoppingCart;
        }

        public ShoppingCartDTO RemoveMenuPromo(ShoppingCartDTO shoppingCart, MenuPromoDTO menuPromo)
        {
            var menuPromoForRemoval = shoppingCart.MenuPromos.FirstOrDefault(mp => mp.MenuPromoId == menuPromo.MenuPromoId);
            if(menuPromoForRemoval == null) throw new IVRestaurantsBusinessException($"There is no {menuPromo.MenuPromoName} promo item in the shopping cart!");

            shoppingCart.MenuPromos.Remove(menuPromoForRemoval);
            var menuPromoPrice = _menuPromoService.CalculateMenuPromoPrice(menuPromo);
            shoppingCart.TotalAmount -= menuPromoPrice;

            return shoppingCart;
        }
    }
}
