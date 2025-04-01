namespace Ambev.DeveloperEvaluation.Application.Carts.ListCarts
{
    public class ListCartsDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BranchName { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ListCartsProductsDto> Products { get; set; }
    }
}
