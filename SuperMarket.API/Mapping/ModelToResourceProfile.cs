using AutoMapper;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Extensions;
using SuperMarket.API.Resources;
namespace SuperMarket.API.Mapping

{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();
            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement, opt => opt.MapFrom(src => src.ToDescriptionString()));
            CreateMap<Tag, TagResource>();
        }
    }
}