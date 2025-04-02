using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProducts
{
    public class ListProductsRequestValidator : AbstractValidator<ListProductsRequest>
    {
        public ListProductsRequestValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0);
            RuleFor(x => x.Size).GreaterThan(0);
        }
    }
}
