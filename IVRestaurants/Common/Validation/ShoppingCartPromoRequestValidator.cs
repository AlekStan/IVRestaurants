using FluentValidation;
using FluentValidation.Results;
using IVRestaurants.Models;

namespace Common.Validation
{
    public class ShoppingCartPromoRequestValidator : AbstractValidator<ShoppingCartPromoRequest>
    {
        public ShoppingCartPromoRequestValidator()
        {
            RuleFor(request => request.MenuPromo).NotNull().NotEmpty();
            RuleFor(request => request.MenuPromo.MenuPromoId).NotNull().GreaterThan(0);
            RuleFor(request => request.MenuPromo.MenuPromoName).NotNull().NotEmpty();
            RuleFor(request => request.MenuPromo.MenuPromoDiscount).InclusiveBetween(0, 100);
            RuleFor(request => request.MenuPromo.MenuPromoItems).NotNull().NotEmpty();
            RuleFor(request => request.ShoppingCart).NotNull();
        }

        public override ValidationResult Validate(ValidationContext<ShoppingCartPromoRequest> context)
        {
            return context.InstanceToValidate == null
             ? new ValidationResult(new[] { new ValidationFailure("ShoppingCartPromoRequest", "Shopping cart request cannot be null") })
             : base.Validate(context);
        }
    }
}
