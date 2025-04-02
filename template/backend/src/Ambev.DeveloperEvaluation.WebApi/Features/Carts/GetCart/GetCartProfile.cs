using Ambev.DeveloperEvaluation.Application.Carts.GetCart;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCart
{
    public class GetCartProfile : Profile
    {
        public GetCartProfile()
        {
            CreateMap<Guid, GetCartCommand>()
                .ConstructUsing(id => new GetCartCommand(id));

            CreateMap<GetCartResult, GetCartResponse>()
                        .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Items));
        }
    }
}
