using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems
{
    public class DeleteCartItemsCommand : IRequest<DeleteCartItemsResponse>
    {
        public Guid CartId { get; set; }

        public DeleteCartItemsCommand(Guid cartId)
        {
            CartId = cartId;
        }
    }
}
