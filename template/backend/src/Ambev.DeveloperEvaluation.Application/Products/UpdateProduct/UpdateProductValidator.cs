using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("ID do produto é obrigatório");

            RuleFor(product => product.Title).SetValidator(new TtileValidator());
            RuleFor(product => product.Description).SetValidator(new DescriptionValidator());
            RuleFor(product => product.Price).SetValidator(new PriceValidator());
            RuleFor(product => product.Category).SetValidator(new CategoryValidator());
            RuleFor(product => product.Image).SetValidator(new ImageValidator());
            RuleFor(product => product.Rating).SetValidator(new RatingValidator());
        }
    }
}
