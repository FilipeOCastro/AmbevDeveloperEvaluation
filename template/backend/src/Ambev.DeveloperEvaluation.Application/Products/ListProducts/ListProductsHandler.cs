using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    public class ListProductsHandler : IRequestHandler<ListProductsCommand, ListProductsResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ListProductsResult> Handle(ListProductsCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListProductsValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var products = await _productRepository.GetAllAsync(request.Page, request.Size, request.Order, cancellationToken);
            var totalItems = await _productRepository.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalItems / request.Size);

            return new ListProductsResult
            {
                Data = products.Select(p => _mapper.Map<ListProductsProductResult>(p)).ToList(),
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }
    }
}
