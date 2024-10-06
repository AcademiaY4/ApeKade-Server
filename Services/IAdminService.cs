using System;
using apekade.Models.Dto;
using apekade.Models.Dto.UserDto;

namespace apekade.Services;

public interface IAdminService
{
    Task<ApiRes> CreateUser(CreateUserDto createUserDto);
    Task<ApiRes> UpdateUser(string id,UpdateUserDto updateUserDto);
    Task<ApiRes> DeactivateUser(string userId);
    Task<ApiRes> ReactivateUser(string userId);
    Task<ApiRes> DeleteUser(string userId);
    Task<ApiRes> GetUserById(string userId);
    Task<ApiRes> GetUserByEmail(string email);
    Task<ApiRes> GetAllUsers();

}
