namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCreateResult
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string BranchName { get; set; }
        public DateTime CreateDate { get; set; }
        public List<CreateCartProductResultDto> Products { get; set; }
    }
}
