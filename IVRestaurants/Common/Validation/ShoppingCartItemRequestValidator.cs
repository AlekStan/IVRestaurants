using Common.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Common.Validation
{
    public class ShoppingCartItemRequestValidator : AbstractValidator<ShoppingCartItemRequest>
    {
        public ShoppingCartItemRequestValidator()
        {
            RuleFor(request => request.MenuItem).NotNull().NotEmpty();
            RuleFor(request => request.MenuItem.MenuItemId).NotNull().GreaterThan(0);
            RuleFor(request => request.MenuItem.MenuItemName).NotNull().NotEmpty();
            RuleFor(request => request.MenuItem.MenuItemPrice).GreaterThan(0);
            RuleFor(request => request.ShoppingCart).NotNull();
        }

        public override ValidationResult Validate(ValidationContext<ShoppingCartItemRequest> context)
        {
            return context.InstanceToValidate == null
             ? new ValidationResult(new[] { new ValidationFailure("ShoppingCartItemRequest", "Shopping cart request cannot be null") })
             : base.Validate(context);
        }
    }
}
