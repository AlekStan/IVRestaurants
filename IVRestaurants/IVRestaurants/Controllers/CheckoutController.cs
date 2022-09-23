using BusinessLogic.Services.Interfaces;
using Common.Exceptions;
using Common.Models;
using Common.Validation;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace IVRestaurants.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IOrderService _orderService;
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(IShoppingCartService shoppingCartService, IOrderService orderService, ILogger<CheckoutController> logger)
        {
            _shoppingCartService = shoppingCartService;
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        [Route("v1/addItem")]
        public ActionResult<ShoppingCartDTO> AddItemToShoppingCart(ShoppingCartItemRequest request)
        {
            ShoppingCartItemRequestValidator validator = new ShoppingCartItemRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Bad request has been sent!");
                foreach (var error in validationResult.Errors) _logger.LogError($"Error: {error}");
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var shoppingCart = request.ShoppingCart;
            var menuItem = request.MenuItem;

            _shoppingCartService.AddMenuItem(shoppingCart, menuItem);

            return Ok(shoppingCart);
        }
        [HttpPost]
        [Route("v1/addPromo")]
        public ActionResult<ShoppingCartDTO> AddPromoToShoppingCart(ShoppingCartPromoRequest request)
        {
            ShoppingCartPromoRequestValidator validator = new ShoppingCartPromoRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Bad request has been sent!");
                foreach (var error in validationResult.Errors) _logger.LogError($"Error: {error}");
                return new StatusCodeResult(StatusCodes.Status400BadRequest);
            }

            var shoppingCart = request.ShoppingCart;
            var menuPromo = request.MenuPromo;

            _shoppingCartService.AddMenuPromo(shoppingCart, menuPromo);

            return Ok(shoppingCart);
        }
        [HttpPost]
        [Route("v1/removeItem")]
        public ActionResult<ShoppingCartDTO> RemoveItemFromShoppingCart(ShoppingCartItemRequest request)
        {
            ShoppingCartItemRequestValidator validator = new ShoppingCartItemRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Bad request has been sent!");
                foreach (var error in validationResult.Errors) _logger.LogError($"Error: {error}");
                return BadRequest(request);
            }

            var shoppingCart = request.ShoppingCart;
            var menuItem = request.MenuItem;

            try
            {
                _shoppingCartService.RemoveMenuItem(shoppingCart, menuItem);
            }
            catch (IVRestaurantsBusinessException exception)
            {
                _logger.LogError(exception?.Message);
                return BadRequest(request);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return StatusCode(500);
            }

            return Ok(shoppingCart);
        }
        [HttpPost]
        [Route("v1/removePromo")]
        public ActionResult<ShoppingCartDTO> RemovePromoFromShoppingCart(ShoppingCartPromoRequest request)
        {
            ShoppingCartPromoRequestValidator validator = new ShoppingCartPromoRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Bad request has been sent!");
                foreach (var error in validationResult.Errors) _logger.LogError($"Error: {error}");
                return BadRequest(request);
            }

            var shoppingCart = request.ShoppingCart;
            var menuPromo = request.MenuPromo;

            try
            {
                _shoppingCartService.RemoveMenuPromo(shoppingCart, menuPromo);
            }
            catch (IVRestaurantsBusinessException exception)
            {
                _logger.LogError(exception?.Message);
                return BadRequest(request);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return StatusCode(500);
            }

            return Ok(shoppingCart);
        }

        [HttpPost]
        [Route("v1/createOrder")]
        public ActionResult<OrderDTO> CreateOrderOnCheckout(ShoppingCartOrderRequest request)
        {
            OrderDTO orderResult;
            ShoppingCartOrderRequestValidator validator = new ShoppingCartOrderRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.LogError("Bad request has been sent!");
                foreach (var error in validationResult.Errors) _logger.LogError($"Error: {error}");
                return BadRequest(request);
            }

            try
            {
                orderResult = _orderService.CreateOrder(request.ShoppingCart);
                if(orderResult == null) return StatusCode(500);
            }
            catch (IVRestaurantsBusinessException exception)
            {
                _logger.LogError(exception?.Message);
                return BadRequest(request);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message);
                return StatusCode(500);
            }

            return Ok(orderResult);
        }
    }
}
