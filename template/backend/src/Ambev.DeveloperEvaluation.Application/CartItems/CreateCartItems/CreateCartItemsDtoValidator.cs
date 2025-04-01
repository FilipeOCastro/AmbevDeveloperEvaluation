using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems
{
    public class CreateCartItemsDtoValidator : AbstractValidator<CreateCartItemsDto>
    {
        public CreateCartItemsDtoValidator()
        {
            RuleFor(cartItem => cartItem.ProductId).NotEmpty().WithMessage("ProductId não pode estar vazio.");
            RuleFor(cartItem => cartItem.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que 0.");
        }
    }
}
