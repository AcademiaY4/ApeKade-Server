using AutoMapper;
using apekade.Models;
using apekade.Models.Dto.AuthDto;

namespace apekade.Configuration;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // CreateMap<UserReqtDto, User>();
        // CreateMap<User, UserResDto>();

        CreateMap<RegisterDto, User>();
        CreateMap<User, RegisterResDto>();
    }
}