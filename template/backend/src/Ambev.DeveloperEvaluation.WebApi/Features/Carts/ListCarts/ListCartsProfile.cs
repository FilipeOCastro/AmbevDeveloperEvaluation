using Ambev.DeveloperEvaluation.Application.Carts.ListCarts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.ListCarts
{
    public class ListCartProfile : Profile
    {
        public ListCartProfile()
        {
            CreateMap<ListCartsRequest, ListCartsCommand>();
            CreateMap<ListCartsDto, ListCartsResponse>();
        }
    }
}
