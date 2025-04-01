namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems
{
    public class CreateCartItemsDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
