using BusinessLogic.Services.Interfaces;
using Common.Helpers.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services.Implementations
{
    public class DiscountService : IDiscountService
    {
        private const decimal HAPPY_HOUR_DISCOUNT = 0.8m;

        private readonly IDateTimeHelper _dateTimeHelper;

        public DiscountService(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }

        public ShoppingCartDTO GetPriceWithDiscount(ShoppingCartDTO shoppingCart)
        {
            var startHour = 13;
            var endHour = 15;
            var utcNow = _dateTimeHelper.GetUTCNow();

            if(utcNow.Hour >= startHour && utcNow.Hour < endHour)
            {
                foreach(var menuItem in shoppingCart.MenuItems)
                {
                    menuItem.MenuItemPrice = menuItem.MenuItemPrice * HAPPY_HOUR_DISCOUNT;
                }

                foreach (var menuPromo in shoppingCart.MenuPromos)
                {
                    menuPromo.MenuPromoPrice = menuPromo.MenuPromoPrice * HAPPY_HOUR_DISCOUNT;
                }

                shoppingCart.TotalAmount = shoppingCart.TotalAmount * HAPPY_HOUR_DISCOUNT;
            }

            return shoppingCart;
        }
    }
}
