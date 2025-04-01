using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCreateResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCartHandler(ICartRepository cartRepository, IMapper mapper, IMediator mediator)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateCreateResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCartValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = _mapper.Map<Cart>(command);
            var createdCart = await _cartRepository.CreateAsync(cart, cancellationToken);

            var createCartItemCommand = new CreateCartItemsCommand(createdCart.Id, _mapper.Map<List<CreateCartItemsDto>>(command.Products));

            var cartItems = await _mediator.Send(createCartItemCommand, cancellationToken);

            var result = _mapper.Map<CreateCreateResult>(cart);
            result.Products = _mapper.Map<List<CreateCartProductResultDto>>(cartItems.CartItems);
            return result;
        }
    }
}
