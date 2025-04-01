using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems
{
    public class CreateCartItemsHandler : IRequestHandler<CreateCartItemsCommand, CreateCartItemsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateCartItemsHandler(ICartItemRepository cartItemRepository, IMapper mapper, ICartRepository cartRepository, IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task<CreateCartItemsResult> Handle(CreateCartItemsCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCartItemsValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(command.CartId, cancellationToken);
            if (cart == null)
                throw new KeyNotFoundException($"CartID {command.CartId} não encontrado");

            cart.Items?.Clear();
            foreach (var itemDto in command.Carttems)
            {
                var product = await _productRepository.GetByIdAsync(itemDto.ProductId);
                var cartItem = _mapper.Map<CartItem>(itemDto);
                cartItem.UnitPrice = product.Price;
                cartItem.CartId = command.CartId;
                cart.AddItem(cartItem);
                await _cartItemRepository.CreateAsync(cartItem, cancellationToken);
            }

            var result = new CreateCartItemsResult()
            {
                CarttId = command.CartId,
                CartItems = _mapper.Map<List<CreateCartItemsDto>>(cart.Items)
            };

            return result;
        }
    }
}
