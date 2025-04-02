using Ambev.DeveloperEvaluation.Application.Cats.UpdateCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequestValidator : AbstractValidator<UpdateCartRequest>
    {
        public UpdateCartRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Cart ID is required");

            RuleFor(cart => cart.UserId).NotEmpty().WithMessage("UserId cannot be empty.");
            RuleForEach(cart => cart.Products).SetValidator(new UpdateCartProductValidator());
        }
    }
}
