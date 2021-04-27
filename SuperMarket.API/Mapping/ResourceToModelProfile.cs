using AutoMapper;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Resources;
namespace SuperMarket.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveTagResource, Tag>();
        }
    }
}