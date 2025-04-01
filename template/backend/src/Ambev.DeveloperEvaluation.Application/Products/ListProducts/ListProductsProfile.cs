using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProducts
{
    public class ListProductsProfile : Profile
    {
        public ListProductsProfile()
        {
            CreateMap<Product, ListProductsProductResult>()
                .ForMember(dest =>
                    dest.Rating,
                    opt =>
                        opt.MapFrom(src => new Rating(src.Rating.Rate, src.Rating.Count)));

            CreateMap<IEnumerable<Product>, ListProductsResult>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
        }
    }
}
