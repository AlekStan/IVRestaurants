using BusinessLogic.Mapper;
using BusinessLogic.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IDiscountService _discountService;
        private readonly IOrderRepository orderRepository;
        private readonly IMenuPromoRepository menuPromoRepository;
        private readonly IMenuItemRepository menuItemRepository;
        public OrderService(IDiscountService discountService, IVRestaurantsContext context)
        {
            _discountService = discountService;
            orderRepository = new OrderRepository(context);
            menuPromoRepository = new MenuPromoRepository(context);
            menuItemRepository = new MenuItemRepository(context);
        }
        public OrderDTO CreateOrder(ShoppingCartDTO shoppingCart)
        {
            _discountService.GetPriceWithDiscount(shoppingCart);

            var orderForCreation = OrderMapper.MapShoppingCartDTOToOrder(shoppingCart);

            orderRepository.Add(orderForCreation);
            var result = orderRepository.SaveChanges();

            if(result == GetNumberOfNewEntities(orderForCreation))
            {
                var orderCreationResult = OrderMapper.MapOrderToOrderDTO(orderForCreation);

                PopulateOrderWithMenuItemNames(orderCreationResult.MenuItems);
                PopulateOrderWithPromoNames(orderCreationResult.MenuPromos);
               
                return orderCreationResult;
            }
            return new OrderDTO();
        }
        private int GetNumberOfNewEntities(Order orderForCreation)
        {
            return orderForCreation.OrderMenuItems.Count + orderForCreation.OrderMenuPromos.Count + 1;
        }

        private void PopulateOrderWithPromoNames(List<OrderMenuPromoDTO> menuPromos)
        {
            if (menuPromos.Any())
            {
                foreach (var menuPromo in menuPromos)
                {
                    var menuPromoFromRepository = menuPromoRepository.GetById(menuPromo.Id);
                    if (menuPromoFromRepository != null)
                    {
                        menuPromo.Name = menuPromoFromRepository.MenuPromoName;
                    }
                }
            }
        }
        private void PopulateOrderWithMenuItemNames(List<OrderMenuItemDTO> menuItems)
        {
            if (menuItems.Any())
            {
                foreach (var menuItem in menuItems)
                {
                    var menuItemFromRepository = menuItemRepository.GetById(menuItem.Id);
                    if (menuItemFromRepository != null)
                    {
                        menuItem.Name = menuItemFromRepository.MenuItemName;
                    }
                }
            }
        }
    }
}
