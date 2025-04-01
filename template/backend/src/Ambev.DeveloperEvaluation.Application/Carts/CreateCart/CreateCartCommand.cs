using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartCommand : IRequest<CreateCreateResult>
    {
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string BranchName { get; set; }
        public List<CreateCartProductDto> Products { get; set; }
    }
}
