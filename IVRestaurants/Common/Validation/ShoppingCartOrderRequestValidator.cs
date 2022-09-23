using Common.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Common.Validation
{
    public class ShoppingCartOrderRequestValidator : AbstractValidator<ShoppingCartOrderRequest>
    {
        public ShoppingCartOrderRequestValidator()
        {
            RuleFor(request => request.ShoppingCart).NotNull().NotEmpty();
            RuleFor(request => request.ShoppingCart.TotalAmount).GreaterThan(0);
            RuleFor(request => request.ShoppingCart.MenuItems).NotEmpty().When(request => request.ShoppingCart.MenuPromos.Count == 0);
            RuleFor(request => request.ShoppingCart.MenuPromos).NotEmpty().When(request => request.ShoppingCart.MenuItems.Count == 0);
        }

        public override ValidationResult Validate(ValidationContext<ShoppingCartOrderRequest> context)
        {
            return context.InstanceToValidate == null
             ? new ValidationResult(new[] { new ValidationFailure("ShoppingCartOrderRequest", "Shopping cart request cannot be null") })
             : base.Validate(context);
        }
    }
}
