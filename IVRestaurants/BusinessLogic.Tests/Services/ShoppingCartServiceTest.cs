using BusinessLogic.Services.Implementations;
using BusinessLogic.Services.Interfaces;
using Common.Exceptions;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests.Services
{
    public class ShoppingCartServiceTest
    {
        [Test]
        public void AddMenuItem_InsertsItemToCart()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();
            var service = new ShoppingCartService(menuPromoService.Object);
            var shoppingCart = new ShoppingCartDTO();
            var menuItem = new MenuItemDTO
            {
                MenuItemId = 2,
                MenuItemName = "Yogurt",
                MenuItemPrice = 2.5m,
                RestaurantId = 1
            };

            //act
            service.AddMenuItem(shoppingCart, menuItem);

            //assert
            Assert.IsNotEmpty(shoppingCart.MenuItems);
            Assert.That(shoppingCart.TotalAmount, Is.EqualTo(2.5m));
        }

        [Test]
        public void AddMenuItem_CalculatesTotalAmount()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();

            var service = new ShoppingCartService(menuPromoService.Object);

            var shoppingCart = new ShoppingCartDTO
            {
                MenuItems = new List<MenuItemDTO>
                {
                    new MenuItemDTO
                    {
                        MenuItemId = 2,
                        MenuItemName = "Yogurt",
                        MenuItemPrice = 2.5m,
                        RestaurantId = 1
                    },
                    new MenuItemDTO
                    {
                        MenuItemId = 1,
                        MenuItemName = "Eggs",
                        MenuItemPrice = 5,
                        RestaurantId = 1
                    },
                    new MenuItemDTO
                    {
                        MenuItemId = 4,
                        MenuItemName = "MealOfTheDay",
                        MenuItemPrice = 10,
                        RestaurantId = 1
                    }
                },
                TotalAmount = 17.5m
            };
            var menuItem = new MenuItemDTO
            {
                MenuItemId = 2,
                MenuItemName = "Yogurt",
                MenuItemPrice = 2.5m,
                RestaurantId = 1
            };

            //act
            service.AddMenuItem(shoppingCart, menuItem);

            //assert
            Assert.That(shoppingCart.TotalAmount, Is.EqualTo(20));
        }

        [Test]
        public void AddMenuPromo_InsertsPromoToCart()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();
            menuPromoService.Setup(x => x.CalculateMenuPromoPrice(It.IsAny<MenuPromoDTO>())).Returns(15.3m);

            var service = new ShoppingCartService(menuPromoService.Object);

            var shoppingCart = new ShoppingCartDTO();
            
            var menuPromo = new MenuPromoDTO
            {
                MenuPromoId = 2,
                MenuPromoName = "LunchSpecial",
                MenuPromoDiscount = 10,
                RestaurantId = 1,
                MenuPromoItems = new List<MenuPromoItemDTO>
                {
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 3
                        },
                        MenuPromoItemId = 3
                    },
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 4
                        },
                        MenuPromoItemId = 4
                    },
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 5
                        },
                        MenuPromoItemId = 5
                    }
                }
            };

            //act
            service.AddMenuPromo(shoppingCart, menuPromo);

            //assert
            Assert.IsNotEmpty(shoppingCart.MenuPromos);
            Assert.That(shoppingCart.TotalAmount, Is.EqualTo(15.3));
        }

        [Test]
        public void RemoveMenuItem_RemovesItemFromCart()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();
            var service = new ShoppingCartService(menuPromoService.Object);
            var shoppingCart = new ShoppingCartDTO
            {
                MenuItems = new List<MenuItemDTO>
                {
                    new MenuItemDTO
                    {
                        MenuItemId = 2,
                        MenuItemName = "Yogurt",
                        MenuItemPrice = 2.5m,
                        RestaurantId = 1
                    },
                    new MenuItemDTO
                    {
                        MenuItemId = 1,
                        MenuItemName = "Eggs",
                        MenuItemPrice = 5,
                        RestaurantId = 1
                    }
                },
                TotalAmount = 7.5m
            };
            var menuItem = new MenuItemDTO
            {
                MenuItemId = 2,
                MenuItemName = "Yogurt",
                MenuItemPrice = 2.5m,
                RestaurantId = 1
            };

            //act
            service.RemoveMenuItem(shoppingCart, menuItem);

            //assert
            Assert.IsNotEmpty(shoppingCart.MenuItems);
            Assert.That(shoppingCart.TotalAmount, Is.EqualTo(5));
        }

        [Test]
        public void RemoveMenuItem_RemovesNonExistingItemFromCart()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();
            var service = new ShoppingCartService(menuPromoService.Object);
            var shoppingCart = new ShoppingCartDTO
            {
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
                TotalAmount = 5
            };
            var menuItem = new MenuItemDTO
            {
                MenuItemId = 2,
                MenuItemName = "Yogurt",
                MenuItemPrice = 2.5m,
                RestaurantId = 1
            };

            //assert
            Assert.Throws<IVRestaurantsBusinessException>(() => service.RemoveMenuItem(shoppingCart, menuItem));
        }

        [Test]
        public void RemoveMenuPromo_RemovesPromoFromCart()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();
            menuPromoService.Setup(x => x.CalculateMenuPromoPrice(It.IsAny<MenuPromoDTO>())).Returns(15.3m);

            var service = new ShoppingCartService(menuPromoService.Object);

         
            var menuPromo = new MenuPromoDTO
            {
                MenuPromoId = 2,
                MenuPromoName = "LunchSpecial",
                MenuPromoDiscount = 10,
                RestaurantId = 1,
                MenuPromoItems = new List<MenuPromoItemDTO>
                {
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 3
                        },
                        MenuPromoItemId = 3
                    },
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 4
                        },
                        MenuPromoItemId = 4
                    },
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 5
                        },
                        MenuPromoItemId = 5
                    }
                }
            };
            var shoppingCart = new ShoppingCartDTO
            {
                MenuPromos = new List<MenuPromoDTO> { menuPromo },
                TotalAmount = 15.3m
            };

            //act
            service.RemoveMenuPromo(shoppingCart, menuPromo);

            //assert
            Assert.IsEmpty(shoppingCart.MenuPromos);
        }

        [Test]
        public void RemoveMenuPromo_RemovesPromoFromEmptyCart()
        {
            //arrange
            var menuPromoService = new Mock<IMenuPromoService>();
            menuPromoService.Setup(x => x.CalculateMenuPromoPrice(It.IsAny<MenuPromoDTO>())).Returns(15.3m);

            var service = new ShoppingCartService(menuPromoService.Object);

            var menuPromo = new MenuPromoDTO
            {
                MenuPromoId = 2,
                MenuPromoName = "LunchSpecial",
                MenuPromoDiscount = 10,
                RestaurantId = 1,
                MenuPromoItems = new List<MenuPromoItemDTO>
                {
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 3
                        },
                        MenuPromoItemId = 3
                    },
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 4
                        },
                        MenuPromoItemId = 4
                    },
                    new MenuPromoItemDTO
                    {
                        MenuItem = new MenuItemDTO
                        {
                            MenuItemId = 5
                        },
                        MenuPromoItemId = 5
                    }
                }
            };
            var shoppingCart = new ShoppingCartDTO();

            //assert
            Assert.Throws<IVRestaurantsBusinessException>(() => service.RemoveMenuPromo(shoppingCart, menuPromo));
        }
    }
}
