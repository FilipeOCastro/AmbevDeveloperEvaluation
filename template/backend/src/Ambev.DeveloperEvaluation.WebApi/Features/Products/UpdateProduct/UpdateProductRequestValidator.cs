using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required");

            RuleFor(product => product.Title).SetValidator(new TtileValidator());
            RuleFor(product => product.Description).SetValidator(new DescriptionValidator());
            RuleFor(product => product.Price).SetValidator(new PriceValidator());
            RuleFor(product => product.Category).SetValidator(new CategoryValidator());
            RuleFor(product => product.Image).SetValidator(new ImageValidator());
            RuleFor(product => product.Rating).SetValidator(new RatingValidator());
        }
    }
}
