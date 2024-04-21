using AutoMapper;
using Inforce.BLL.DTO.Authentication.Register;
using Inforce.DAL.Entities.Users;

namespace Inforce.BLL.Mapping.Authentication;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<User, RegisterResponseDTO>().ReverseMap();
        CreateMap<User, RegisterRequestDTO>().ReverseMap();
    }
}