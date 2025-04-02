using Ambev.DeveloperEvaluation.Application.Cats.UpdateCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<UpdateCartProductDto> Products { get; set; }
    }
}
