using DataAccessLayer.Models;
using Domain.Models;

namespace BusinessLogic.Mapper
{
    public static class OrderMapper
    {
        public static OrderDTO MapOrderToOrderDTO(Order order)
        {
            return new OrderDTO
            {
                Id = order.OrderId,
                MenuItems = MapMenuItemToOrderMenuItemDTO(order.OrderMenuItems.ToList()),
                MenuPromos = MapMenuPromoToOrderMenuPromoDTO(order.OrderMenuPromos.ToList()),
                TotalAmount = order.TotalAmount,
            };
        }

        public static Order MapShoppingCartDTOToOrder(ShoppingCartDTO shoppingCart)
        {
            return new Order
            {
                OrderMenuItems = MapMenuItemDTOToMenuItem(shoppingCart.MenuItems.ToList()),
                OrderMenuPromos = MapMenuPromoDTOToMenuPromo(shoppingCart.MenuPromos.ToList()),
                TotalAmount = shoppingCart.TotalAmount
            };
        }

        private static List<OrderMenuPromoDTO> MapMenuPromoToOrderMenuPromoDTO(List<OrderMenuPromo> menupromos)
        {
            var menuPromoList = new List<OrderMenuPromoDTO>();
            foreach(var menuPromo in menupromos)
            {
                menuPromoList.Add(new OrderMenuPromoDTO
                {
                    Id = menuPromo.MenuPromoId,
                    Price = menuPromo.MenuPromoPrice
                });
            }
            return menuPromoList;
        }

        private static List<OrderMenuItemDTO> MapMenuItemToOrderMenuItemDTO(List<OrderMenuItem> menuItems)
        {
            var menuItemsList = new List<OrderMenuItemDTO>();
            foreach (var menuItem in menuItems)
            {
                menuItemsList.Add(new OrderMenuItemDTO
                {
                   Id = menuItem.MenuItemId,
                   Price = menuItem.MenuItemPrice
                });
            }

            return menuItemsList;
        }

        private static List<OrderMenuPromo> MapMenuPromoDTOToMenuPromo(List<MenuPromoDTO> menuPromos)
        {
            var orderMenuPromoList = new List<OrderMenuPromo>();

            foreach(var menuPromo in menuPromos)
            {
                orderMenuPromoList.Add(new OrderMenuPromo
                {
                    MenuPromoId = menuPromo.MenuPromoId,
                    MenuPromoPrice = menuPromo.MenuPromoPrice
                });
            }

            return orderMenuPromoList;
        }

        private static List<OrderMenuItem> MapMenuItemDTOToMenuItem(List<MenuItemDTO> menuItems)
        {
            var orderMenuItemList = new List<OrderMenuItem>();

            foreach(var menuItem in menuItems)
            {
                orderMenuItemList.Add(new OrderMenuItem
                {
                    MenuItemId = menuItem.MenuItemId,
                    MenuItemPrice = menuItem.MenuItemPrice
                });
            }

            return orderMenuItemList;
        }

        private static MenuItem MapMenuItemDtoToOrderMenuItem(MenuItemDTO menuItem)
        {
            return new MenuItem
            {
                MenuItemId = menuItem.MenuItemId,
                MenuItemName = menuItem.MenuItemName,
                MenuItemPrice = menuItem.MenuItemPrice,
                RestaurantId = menuItem.RestaurantId
            };
        }
    }
}
