using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductReturnDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(d => d.Brand.Name))
                .ForMember(d => d.Type, o => o.MapFrom(d => d.Type.Name));
        }
    }
}
