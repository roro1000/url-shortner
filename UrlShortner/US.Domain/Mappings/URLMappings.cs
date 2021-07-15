using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Domain.Mapping
{
    public class URLMappings : Profile
    {
        public URLMappings()
        {
            CreateMap<URL, URLDetails>()
                .ForMember(dest => dest.ShortUrl, opt => opt.MapFrom(src => src.ShortValue));
        }
    }
}
