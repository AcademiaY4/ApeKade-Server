using apekade.Models.Dto;
using apekade.Models.Dto.UserDto;

namespace apekade.Services;

public interface IUserService
{
    Task<ApiRes<UserTokenResDto>> CreateNewUser(UserReqtDto userReqtDto);
}