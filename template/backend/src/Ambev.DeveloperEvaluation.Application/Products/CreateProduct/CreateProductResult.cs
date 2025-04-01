using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct
{
    public class CreateProductResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = String.Empty;

        public string Category { get; set; }

        public string Image { get; set; }

        public Rating Rating { get; set; }
    }
}
