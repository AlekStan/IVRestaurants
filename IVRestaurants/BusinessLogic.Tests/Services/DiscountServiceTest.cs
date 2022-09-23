using BusinessLogic.Services.Implementations;
using Common.Helpers.Interfaces;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests.Services
{
    public class DiscountServiceTest
    {
        [Test]
        public void ApplyHappyHourDiscount()
        {
            //arrange
            var dateTimeHelper = new Mock<IDateTimeHelper>();

            dateTimeHelper.Setup(x => x.GetUTCNow()).Returns(new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 14, 30, 30));
            var shoppingCart = new ShoppingCartDTO()
            {
                TotalAmount = 12.5m,
                MenuItems = new List<MenuItemDTO>
                {
                    new MenuItemDTO
                    {
                        MenuItemId = 1,
                        MenuItemName = "Eggs",
                        MenuItemPrice = 5,
                        RestaurantId = 1
                    }
                },
                MenuPromos = new List<MenuPromoDTO>
                {
                    new MenuPromoDTO
                    {
                        MenuPromoDiscount = 10,
                        MenuPromoId = 1,
                        MenuPromoName = "BreakfastMeal",
                        MenuPromoPrice = 7.5m,
                        RestaurantId = 1,
                        MenuPromoItems = new List<MenuPromoItemDTO>
                        {
                            new MenuPromoItemDTO
                            {
                                MenuItem = new MenuItemDTO
                                {
                                    MenuItemId = 1
                                },
                                MenuPromoItemId = 1
                            },
                            new MenuPromoItemDTO
                            {
                                MenuItem = new MenuItemDTO
                                {
                                    MenuItemId = 2
                                },
                                MenuPromoItemId = 2
                            }
                        }   
                    }
                }
            };

            var service = new DiscountService(dateTimeHelper.Object);
          
            //act
            var testResult = service.GetPriceWithDiscount(shoppingCart);

            //assert
            Assert.That(testResult.TotalAmount, Is.EqualTo(10m));
        }
    }
}
