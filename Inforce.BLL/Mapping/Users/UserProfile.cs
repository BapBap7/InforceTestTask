using AutoMapper;
using Inforce.BLL.DTO.Users;
using Inforce.DAL.Entities.Users;

namespace Inforce.BLL.Mapping.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}