using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems
{
    public class CreateCartItemsProfile : Profile
    {
        public CreateCartItemsProfile()
        {
            CreateMap<CreateCartItemsDto, CartItem>().ReverseMap();
        }
    }
}
