using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CategoryValidator : AbstractValidator<string>
    {
        public CategoryValidator()
        {
            RuleFor(category => category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
        }
    }

    public class DescriptionValidator : AbstractValidator<string>
    {
        public DescriptionValidator()
        {
            RuleFor(description => description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(100).WithMessage("Description must not exceed 100 characters.");
        }
    }

    public class ImageValidator : AbstractValidator<string>
    {
        public ImageValidator()
        {
            RuleFor(image => image)
                .NotEmpty().WithMessage("Image URL is required.")
                .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute)).WithMessage("Image URL must be a valid URL.");
        }
    }

    public class PriceValidator : AbstractValidator<decimal>
    {
        public PriceValidator()
        {
            RuleFor(price => price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title).SetValidator(new TtileValidator());
            RuleFor(product => product.Description).SetValidator(new DescriptionValidator());
            RuleFor(product => product.Price).SetValidator(new PriceValidator());
            RuleFor(product => product.Category).SetValidator(new CategoryValidator());
            RuleFor(product => product.Image).SetValidator(new ImageValidator());
            RuleFor(product => product.Rating).SetValidator(new RatingValidator());
        }
    }

    public class RatingValidator : AbstractValidator<Rating>
    {
        public RatingValidator()
        {
            RuleFor(rating => rating.Rate)
                .InclusiveBetween(1, 5).WithMessage("Rating value must be between 1 and 5.");

            RuleFor(rating => rating.Count)
                .GreaterThanOrEqualTo(0).WithMessage("Rating count must be greater than or equal to 0.");
        }
    }

    public class TtileValidator : AbstractValidator<string>
    {
        public TtileValidator()
        {
            RuleFor(title => title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
        }
    }
}
