using FluentValidation;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartProductValidator : AbstractValidator<CreateCartProductDto>
    {
        public CreateCartProductValidator()
        {
            RuleFor(product => product.ProductId).NotEmpty().WithMessage("ProductId não pode estar vazio.");
            RuleFor(product => product.Quantity).GreaterThan(0).WithMessage("A quantidade deve ser maior que 0.");
        }
    }
}
