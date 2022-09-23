using Domain.Models;

namespace BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        public OrderDTO CreateOrder(ShoppingCartDTO shoppingCart);
    }
}
