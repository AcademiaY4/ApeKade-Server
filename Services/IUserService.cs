using apekade.Dto;
using apekade.Dto.UserDto;

namespace apekade.Services;

public interface IUserService
{
    Task<ApiRes<UserTokenResDto>> CreateNewUser(UserReqtDto userReqtDto);
}