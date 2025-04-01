using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory
{
    public class ListProductsByCategoryResult : PaginatedResult
    {
        public List<ListProductsByCategoryProductDto> Data { get; set; }
    }
}
