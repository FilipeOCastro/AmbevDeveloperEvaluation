using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Cats.UpdateCart
{
    public class UpdateCartProductValidator : AbstractValidator<UpdateCartProductDto>
    {
        public UpdateCartProductValidator()
        {
            RuleFor(product => product.ProductId).NotEmpty().WithMessage("ProductId não pode estar vazio.");
            RuleFor(product => product.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que 0.");
        }
    }
}
