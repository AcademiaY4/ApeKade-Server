using AutoMapper;
using apekade.Models;
using apekade.Models.Dto.UserDto;

namespace apekade.Configuration;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<User, UserResDto>();
        CreateMap<UserReqtDto, User>();
    }
}