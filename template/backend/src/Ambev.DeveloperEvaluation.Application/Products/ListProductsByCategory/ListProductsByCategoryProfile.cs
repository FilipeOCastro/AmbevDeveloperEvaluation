using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.ListProductsByCategory
{
    public class ListProductsByCategoryProfile : Profile
    {
        public ListProductsByCategoryProfile()
        {
            CreateMap<Product, ListProductsByCategoryProductDto>()
                .ForMember(dest =>
                    dest.Rating,
                    opt =>
                        opt.MapFrom(src => new Rating(src.Rating.Rate, src.Rating.Count)));

            CreateMap<IEnumerable<Product>, ListProductsByCategoryResult>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
        }
    }
}
