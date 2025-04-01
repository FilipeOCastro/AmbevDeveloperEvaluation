using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory
{
    public class ListProductsByCategoryHandler : IRequestHandler<ListProductsByCategoryCommand, ListProductsByCategoryResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductsByCategoryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ListProductsByCategoryResult> Handle(ListProductsByCategoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListProductsByCategoryValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var products = await _productRepository.GetByCategoryAsync(request.Category, request.Page, request.Size, request.Order, cancellationToken);
            var totalItems = await _productRepository.CountByCategoryAsync(request.Category, cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalItems / request.Size);

            return new ListProductsByCategoryResult
            {
                Data = products.Select(p => _mapper.Map<ListProductsByCategoryProductDto>(p)).ToList(),
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }
    }
}
