using Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.CreateCart
{
    public class CreateCartResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BranchName { get; set; }
        public DateTime CreateDate { get; set; }
        public List<CreateCartProductDto> Products { get; set; }
    }
}
