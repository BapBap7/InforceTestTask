using AutoMapper;
using Inforce.BLL.DTO.Shorten;
using Inforce.DAL.Entities.Shortener;

namespace Inforce.BLL.Mapping.Shorten;

public class ShortenUrlProfile : Profile
{
    public ShortenUrlProfile()
    {
        CreateMap<ShortenedUrl, ShortenDTO>().ReverseMap();
        CreateMap<ShortenedUrl, ShortShortenDTO>().ReverseMap();
    }
}