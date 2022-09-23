using Domain.Models;

namespace BusinessLogic.Services.Interfaces
{
    public interface IDiscountService
    {
        public ShoppingCartDTO GetPriceWithDiscount(ShoppingCartDTO shoppingCart);
    }
}
