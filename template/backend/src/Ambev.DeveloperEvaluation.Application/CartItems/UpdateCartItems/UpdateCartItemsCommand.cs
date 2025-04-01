using MediatR;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItems
{
    public class UpdateCartItemsCommand : IRequest<UpdateCartItemsResponse>
    {
        public Guid CartId { get; set; }
        public List<UpdateCartItemsDto> CartItems { get; set; } = new List<UpdateCartItemsDto>();

    }
}
