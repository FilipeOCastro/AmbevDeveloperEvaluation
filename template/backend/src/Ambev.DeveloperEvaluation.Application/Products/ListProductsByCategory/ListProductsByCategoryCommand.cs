using Ambev.DeveloperEvaluation.Application.Common;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory
{
    public class ListProductsByCategoryCommand : PaginatedCommand, IRequest<ListProductsByCategoryResult>
    {
        public string Category { get; set; }
    }
}
