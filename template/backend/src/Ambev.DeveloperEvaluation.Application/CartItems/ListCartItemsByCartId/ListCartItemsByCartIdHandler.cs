using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.ListCartItemsByCartId
{
    public class ListCartItemsByCartIdHandler : IRequestHandler<ListCartItemsByCartIdCommand, ListCartItemsByCartIdResult>
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public ListCartItemsByCartIdHandler(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public async Task<ListCartItemsByCartIdResult> Handle(ListCartItemsByCartIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new ListCartItemsByCartIdValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cartItems = await _cartItemRepository.GetByCartIdAsync(request.CartId, cancellationToken);

            return new ListCartItemsByCartIdResult
            {
                CartId = request.CartId,
                CartItems = cartItems.Select(c => _mapper.Map<ListCartItemsByCartIdDto>(c)).ToList()
            };
        }
    }
}
