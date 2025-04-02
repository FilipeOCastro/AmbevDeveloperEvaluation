using Ambev.DeveloperEvaluation.WebApi.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.ListProductsByCategory
{
    public class ListProductsByCategoryRequest : PaginatedRequest
    {
        public string Category { get; set; }
    }
}
