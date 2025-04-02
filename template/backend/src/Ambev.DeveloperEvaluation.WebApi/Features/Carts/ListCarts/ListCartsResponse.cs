using Ambev.DeveloperEvaluation.Application.Carts.GetCart;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts
{
    public class ListCartsResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BranchName { get; set; }
        public DateTime CreateDate { get; set; }
        public List<GetCartProductsDto> Products { get; set; }
    }
}
