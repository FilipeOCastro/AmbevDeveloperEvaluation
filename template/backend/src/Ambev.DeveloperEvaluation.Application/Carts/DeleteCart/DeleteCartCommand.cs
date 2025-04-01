using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart
{
    public class DeleteCartCommand : IRequest<DeleteCartResponse>
    {
        public Guid Id { get; set; }

        public DeleteCartCommand(Guid id)
        {
            Id = id;
        }
    }
}
