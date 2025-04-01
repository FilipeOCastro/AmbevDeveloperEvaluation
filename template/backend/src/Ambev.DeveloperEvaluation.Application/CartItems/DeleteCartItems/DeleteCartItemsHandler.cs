using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems
{
    public class DeleteCartItemsHandler : IRequestHandler<DeleteCartItemsCommand, DeleteCartItemsResponse>
    {
        private readonly ICartItemRepository _cartItemRepository;

        public DeleteCartItemsHandler(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository ?? throw new ArgumentNullException(nameof(cartItemRepository));
        }

        public async Task<DeleteCartItemsResponse> Handle(DeleteCartItemsCommand request, CancellationToken cancellationToken)
        {
            var cartItem = await _cartItemRepository.GetByCartIdAsync(request.CartId, cancellationToken);
            if (cartItem == null)
                throw new KeyNotFoundException($"Item de carrinho com CartID {request.CartId} não encontrado");

            var success = await _cartItemRepository.DeleteByCartIdAsync(request.CartId, cancellationToken);
            if (!success)
                throw new InvalidOperationException($"O item do carrinho com CartID {request.CartId} não pode ser excluído");

            return new DeleteCartItemsResponse { Message = $"Item do carrinho com CartID {request.CartId} excluído com sucesso" };
        }
    }
}
