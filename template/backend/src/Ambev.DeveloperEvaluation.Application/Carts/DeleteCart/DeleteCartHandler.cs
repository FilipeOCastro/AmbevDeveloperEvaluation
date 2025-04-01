using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart
{
    public class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResponse>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMediator _mediator;

        public DeleteCartHandler(ICartRepository cartRepository, IMediator mediator)
        {
            _cartRepository = cartRepository;
            _mediator = mediator;
        }

        public async Task<DeleteCartResponse> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCartValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var cart = await _cartRepository.GetByIdAsync(request.Id, cancellationToken);
            if (cart == null)
                throw new KeyNotFoundException($"CartID {request.Id} não encontrado");

            cart.Items?.Clear();
            var success = await _cartRepository.DeleteAsync(request.Id, cancellationToken);
            if (!success)
                throw new KeyNotFoundException($"Carrinho com ID {request.Id} não encontrado");

            return new DeleteCartResponse { Message = $"Carrinho com ID {request.Id} excluído com sucesso" };
        }
    }
}
