using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    public class ListProductsCommand : PaginatedCommand, IRequest<ListProductsResult>
    {
    }
}
