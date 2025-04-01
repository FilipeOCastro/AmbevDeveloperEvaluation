namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItems
{
    public class UpdateCartItemsResponse
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public List<UpdateCartItemsDto> CartItems { get; set; }
    }
}
