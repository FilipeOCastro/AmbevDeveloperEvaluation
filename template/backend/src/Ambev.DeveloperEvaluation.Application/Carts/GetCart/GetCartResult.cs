namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BranchName { get; set; }
        public DateTime CreateDate { get; set; }
        public List<GetCartProductsDto> Items { get; set; }
    }
}
