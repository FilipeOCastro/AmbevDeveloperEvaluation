namespace Ambev.DeveloperEvaluation.Application.CartItems.ListCartItemsByCartId
{
    public class ListCartItemsByCartIdResult
    {
        public Guid CartId { get; set; }
        public List<ListCartItemsByCartIdDto> CartItems { get; set; }
    }
}
