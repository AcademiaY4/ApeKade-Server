// ------------------------------------------------------------
// File: IAdminService.cs
// Description: Interface for admin-related services, managing user accounts
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;
using apekade.Models.Dto.AuthDto;
using apekade.Models.Dto.UserDto;

namespace apekade.Services;

public interface IAdminService
{
    // Method to create a new user
    Task<ApiRes> CreateUser(CreateUserDto createUserDto);

    // Method to update an existing user
    Task<ApiRes> UpdateUser(string id, UpdateUserDto updateUserDto);

    // Method to deactivate a user account
    Task<ApiRes> DeactivateUser(string userId);

    // Method to reactivate a deactivated user account
    Task<ApiRes> ReactivateUser(string userId);

    // Method to delete a user account
    Task<ApiRes> DeleteUser(string userId);

    // Method to retrieve a user by their ID
    Task<ApiRes> GetUserById(string userId);

    // Method to retrieve a user by their email address
    Task<ApiRes> GetUserByEmail(string email);

    // Method to change a user's password
    Task<ApiRes> ChangeUserPassword(string userId, ChangePasswordDto changePasswordDto);

    // Method to change a user's password without validation checks
    Task<ApiRes> ChangePwdWoChk(string userId, ChangePwdWoChkDto changePwdWoChkDto);
    
    // Method to retrieve all users
    Task<ApiRes> GetAllUsers();
}
