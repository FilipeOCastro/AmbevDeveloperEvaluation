using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories
{
    public class ListCategoriesHandler : IRequestHandler<ListCategoriesCommand, ListCategoriesResult>
    {
        private readonly IProductRepository _productRepository;

        public ListCategoriesHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ListCategoriesResult> Handle(ListCategoriesCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListCategoriesValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var categories = await _productRepository.GetCategoriesAsync(cancellationToken);

            return new ListCategoriesResult
            {
                Categories = categories.ToList()
            };
        }
    }
}
