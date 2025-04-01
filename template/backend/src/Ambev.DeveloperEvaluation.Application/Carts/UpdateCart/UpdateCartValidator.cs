using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Cats.UpdateCart
{
    public class UpdateCartValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartValidator()
        {
            RuleFor(cart => cart.UserId).NotEmpty().WithMessage("UserId não pode estar vazio.");
            RuleForEach(cart => cart.Products).SetValidator(new UpdateCartProductValidator());
        }
    }
}
