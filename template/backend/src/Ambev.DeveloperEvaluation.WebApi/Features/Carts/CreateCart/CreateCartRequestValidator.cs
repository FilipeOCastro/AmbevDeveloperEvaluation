using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
    {
        public CreateCartRequestValidator()
        {
            RuleFor(cart => cart.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
            RuleForEach(cart => cart.Products).SetValidator(new CreateCartProductValidator());
        }
    }
}
