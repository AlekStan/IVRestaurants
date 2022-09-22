using BusinessLogic.Services.Implementations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BusinessLogic.Tests.Services
{
    public class MenuPromoServiceTest
    {
        [Test]
        public void CalculateMenuPromoPrice_PromoPriceShouldEqualSumOfItemPricesWithDiscount()
        {
            //arrange
        
            var mockMenuItem = new MenuItem
            {
                MenuItemId = 1,
                MenuItemName = "Eggs",
                MenuItemPrice = 5,
                RestaurantId = 1
            };
            var mockMenuItem2 = new MenuItem
            {
                MenuItemId = 2,
                MenuItemName = "Yogurt",
                MenuItemPrice = 2.5m,
                RestaurantId = 1
            };

            var mockContext = new Mock<IVRestaurantsContext>();
            var mockSet = new Mock<DbSet<MenuItem>>();
            mockContext.Setup(m => m.Set<MenuItem>()).Returns(mockSet.Object);

            mockSet.Setup(x => x.Find(It.Is<int>(s => s == 1))).Returns(mockMenuItem);
            mockSet.Setup(x => x.Find(It.Is<int>(s => s == 2))).Returns(mockMenuItem2);

            var menuPromo = new MenuPromoDTO
            {
                MenuPromoDiscount = 10,
                MenuPromoId = 1,
                MenuPromoName = "BreakfastMeal",
                RestaurantId = 1,
                MenuPromoItems = new List<MenuPromoItemDTO>
                {
                    new MenuPromoItemDTO
                    {
                        MenuPromoItemId = 1,
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 1,
                            MenuItemName = "Eggs",
                            MenuItemPrice = 5,
                            RestaurantId = 1
                        }
                    },
                    new MenuPromoItemDTO
                    {
                        MenuPromoItemId = 2,
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 2,
                            MenuItemName = "Yogurt",
                            MenuItemPrice = 2.5m,
                            RestaurantId = 1
                        }
                    }
                }
            };

            var service = new MenuPromoService(mockContext.Object);

            //act
            var testResult = service.CalculateMenuPromoPrice(menuPromo);

            //assert
            Assert.That(testResult, Is.EqualTo(6.75m));
        }
    }
}
