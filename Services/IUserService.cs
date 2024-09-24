using apekade.Models.Dto;

namespace apekade.Services;

public interface IUserService
{
    // Task<ApiRes> CreateNewUser(UserReqtDto userReqtDto);
    Task<ApiRes> CreateNewUser(string email);
}