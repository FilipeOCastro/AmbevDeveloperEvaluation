using Ambev.DeveloperEvaluation.Application.CartItems.DeleteCartItems;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Cats.UpdateCart
{
    public class UpdateCartCommand : IRequest<UpdateCartResult>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public List<UpdateCartProductDto> Products { get; set; }

    }
}
