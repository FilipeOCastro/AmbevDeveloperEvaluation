namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems
{
    public class CreateCartItemsResult
    {
        public Guid Id { get; set; }
        public Guid CarttId { get; set; }
        public List<CreateCartItemsDto> CartItems { get; set; }
    }
}
