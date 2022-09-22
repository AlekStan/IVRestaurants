using BusinessLogic.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services.Implementations
{
    public class MenuPromoService : IMenuPromoService
    {
        private IMenuItemRepository menuItemRepository;

        public MenuPromoService(IVRestaurantsContext context)
        {
            menuItemRepository = new MenuItemRepository(context);
        }
        public decimal CalculateMenuPromoPrice(MenuPromoDTO menuPromo)
        {
            var totalAmount = 0m;
            var menuItemIds = menuPromo.MenuPromoItems.Select(x => x.MenuItem.MenuItemId).ToList();

            foreach(var menuItemId in menuItemIds)
            {
                var menuItem = menuItemRepository.GetById(menuItemId);
                if (menuItem == null) continue;
                totalAmount += (menuItem.MenuItemPrice * ((100 - menuPromo.MenuPromoDiscount) / 100));
            }

            return totalAmount;
        }
    }
}
