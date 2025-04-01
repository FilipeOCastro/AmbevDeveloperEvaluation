using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    public class ListProductsResult : PaginatedResult
    {
        public List<ListProductsProductResult> Data { get; set; }
    }
}
