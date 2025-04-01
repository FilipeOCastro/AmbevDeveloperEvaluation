using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory
{
    public class ListProductsByCategoryValidator : AbstractValidator<ListProductsByCategoryCommand>
    {
        public ListProductsByCategoryValidator()
        {
            RuleFor(x => x.Category).SetValidator(new CategoryValidator());
        }
    }
}
