using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(product => product.Title).SetValidator(new TtileValidator());
            RuleFor(product => product.Description).SetValidator(new DescriptionValidator());
            RuleFor(product => product.Price).SetValidator(new PriceValidator());
            RuleFor(product => product.Category).SetValidator(new CategoryValidator());
            RuleFor(product => product.Image).SetValidator(new ImageValidator());
            RuleFor(product => product.Rating).SetValidator(new RatingValidator());
        }
    }
}
