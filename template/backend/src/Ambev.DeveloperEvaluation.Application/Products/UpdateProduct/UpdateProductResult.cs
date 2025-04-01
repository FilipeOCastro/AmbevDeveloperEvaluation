using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductResult
    {
        public string Title { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = String.Empty;

        public string Category { get; set; } = String.Empty;

        public string Image { get; set; } = string.Empty;

        public Rating Rating { get; set; } = new Rating(0, 0);
    }
}
