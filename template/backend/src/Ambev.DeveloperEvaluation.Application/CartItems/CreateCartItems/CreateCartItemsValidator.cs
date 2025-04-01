using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems
{
    public class CreateCartItemsValidator : AbstractValidator<CreateCartItemsCommand>
    {
        public CreateCartItemsValidator()
        {
            RuleFor(cartItem => cartItem.CartId).NotEmpty().WithMessage("CartId não pode estar vazio.");
            RuleForEach(cartItem => cartItem.Carttems).SetValidator(new CreateCartItemsDtoValidator());
        }
    }
}
