using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart
{
    public class GetCartProfile : Profile
    {
        public GetCartProfile()
        {
            CreateMap<Cart, GetCartResult>().ReverseMap();
            CreateMap<CartItem, GetCartProductsDto>().ReverseMap();
            CreateMap<ListCartsProductsDto, GetCartProductsDto>().ReverseMap();
        }
    }
}
