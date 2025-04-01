using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems
{
    public class DeleteCartItemsValidator : AbstractValidator<DeleteCartItemsCommand>
    {
        public DeleteCartItemsValidator()
        {
            RuleFor(x => x.CartId)
                .NotEmpty()
                .WithMessage("O ID do carrinho é obrigatório");
        }
    }
}
