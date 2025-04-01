using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartItems.ListCartItemsByCartId
{
    public class ListCartItemsByCartIdProfile : Profile
    {
        public ListCartItemsByCartIdProfile()
        {
            CreateMap<CartItem, ListCartItemsByCartIdDto>();
        }
    }
}
