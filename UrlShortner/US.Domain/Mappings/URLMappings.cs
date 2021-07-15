using AutoMapper;
using Domain.Entities;
using Common.Models;

namespace Domain.Mapping
{
    public class URLMappings : Profile
    {
        public URLMappings()
        {
            CreateMap<URL, URLDetails>()
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code));
        }
    }
}
