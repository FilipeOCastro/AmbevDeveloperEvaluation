using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.ListCartItemsByCartId
{
    public class ListCartItemsByCartIdCommand : PaginatedCommand, IRequest<ListCartItemsByCartIdResult>
    {
        public Guid CartId { get; set; }

        public ListCartItemsByCartIdCommand(Guid cartId)
        {
            CartId = cartId;
        }
    }
}
