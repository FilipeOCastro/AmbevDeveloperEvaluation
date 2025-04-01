using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts
{
    public class ListCartsResult : PaginatedResult
    {
        public List<ListCartsDto> Data { get; set; }
    }
}
