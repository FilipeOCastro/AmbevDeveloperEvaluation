using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts
{
    public class ListCartsCommand : PaginatedCommand, IRequest<ListCartsResult>
    {
    }
}
