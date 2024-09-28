using apekade.Models.Dto;
using apekade.Models.Dto.UserDto;
using apekade.Models.Dto.VendorDto;

namespace apekade.Services;

public interface IUserService
{
    Task<ApiRes> GetUserById(string userId);
    Task<ApiRes> GetUserByEmail(string email);
}