using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts
{
    public class ListCartsHandler : IRequestHandler<ListCartsCommand, ListCartsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public ListCartsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<ListCartsResult> Handle(ListCartsCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListCartsValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var carts = await _cartRepository.GetAllAsync(request.Page, request.Size, request.Order, cancellationToken);
            var totalItems = await _cartRepository.CountAsync(cancellationToken);
            var totalPages = (int)Math.Ceiling((double)totalItems / request.Size);

            return new ListCartsResult
            {
                Data = carts.Select(c => _mapper.Map<ListCartsDto>(c)).ToList(),
                TotalItems = totalItems,
                TotalPages = totalPages
            };
        }
    }
}
