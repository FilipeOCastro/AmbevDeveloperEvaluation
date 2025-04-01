using Ambev.DeveloperEvaluation.Application.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.ListCategories
{
    public class ListCategoriesResult : PaginatedResult
    {
        public List<string> Categories { get; set; }
    }
}
