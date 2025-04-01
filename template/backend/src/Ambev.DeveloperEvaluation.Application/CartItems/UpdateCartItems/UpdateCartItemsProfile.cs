using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartItems.UpdateCartItems
{
    public class UpdateCartItemsProfile : Profile
    {
        public UpdateCartItemsProfile()
        {
            CreateMap<UpdateCartItemsCommand, CartItem>();
            CreateMap<CartItem, UpdateCartItemsDto>();
        }
    }
}
