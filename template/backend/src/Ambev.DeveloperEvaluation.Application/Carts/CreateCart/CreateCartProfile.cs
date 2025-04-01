using Ambev.DeveloperEvaluation.Application.CartItems.CreateCartItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;


namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart
{
    public class CreateCartProfile : Profile
    {
        public CreateCartProfile()
        {
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<Cart, CreateCreateResult>().ReverseMap();
            CreateMap<CreateCartItemsDto, CartItem>().ReverseMap();
            CreateMap<CreateCartItemsDto, CreateCartProductDto>().ReverseMap();
            CreateMap<CreateCartProductDto, CartItem>();
            CreateMap<CreateCartProductResultDto, CreateCartItemsDto>().ReverseMap();
        }
    }
}
