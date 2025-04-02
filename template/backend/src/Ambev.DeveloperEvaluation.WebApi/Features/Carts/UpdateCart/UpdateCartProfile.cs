using Ambev.DeveloperEvaluation.Application.Cats.UpdateCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.UpdateCart
{
    public class UpdateCartProfile : Profile
    {
        public UpdateCartProfile()
        {
            CreateMap<UpdateCartRequest, UpdateCartCommand>();
            CreateMap<UpdateCartResult, UpdateCartResponse>();
        }
    }
}
