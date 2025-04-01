namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartProductsDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
