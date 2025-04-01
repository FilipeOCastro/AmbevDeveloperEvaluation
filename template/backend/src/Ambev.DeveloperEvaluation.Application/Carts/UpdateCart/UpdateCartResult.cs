namespace Ambev.DeveloperEvaluation.Application.Cats.UpdateCart
{
    public class UpdateCartResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<UpdateCartProductDto> Products { get; set; }
    }
}
