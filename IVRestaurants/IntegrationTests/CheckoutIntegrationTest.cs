using Domain.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace IntegrationTests
{
    public class CheckoutIntegrationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CheckoutTest()
        {
            //var application = new WebApplicationFactory<Program>();

            //var client = application.CreateClient();
            //var shoppingCart = new ShoppingCartDTO()
            //{
            //    MenuItems = new List<MenuItemDTO>
            //    {
            //        new MenuItemDTO
            //        {
            //            MenuItemId = 2,
            //            MenuItemName = "Yogurt",
            //            MenuItemPrice = 2.5m,
            //            RestaurantId = 1
            //        },
            //        new MenuItemDTO
            //        {
            //            MenuItemId = 1,
            //            MenuItemName = "Eggs",
            //            MenuItemPrice = 5,
            //            RestaurantId = 1
            //        },
            //        new MenuItemDTO
            //        {
            //            MenuItemId = 4,
            //            MenuItemName = "MealOfTheDay",
            //            MenuItemPrice = 10,
            //            RestaurantId = 1
            //        }
            //    },
            //    TotalAmount = 17.5m
            //}; 
            //var content = JsonConvert.SerializeObject(shoppingCart);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            //var byteContent = new ByteArrayContent(buffer);
            //byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //var result = client.PostAsync("v1/createOrder", byteContent).Result;
        }
    }
}