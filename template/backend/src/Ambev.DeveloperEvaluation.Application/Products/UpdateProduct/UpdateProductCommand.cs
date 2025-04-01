using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : IRequest<UpdateProductResult>
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = String.Empty;

        public string Category { get; set; } = String.Empty;

        public string Image { get; set; } = string.Empty;

        public Rating Rating { get; set; } = new Rating(0, 0);

        public ValidationResultDetail Validate()
        {
            var validator = new UpdateProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
