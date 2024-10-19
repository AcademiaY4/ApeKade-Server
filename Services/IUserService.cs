// ------------------------------------------------------------
// File: IUserService.cs
// Description: Interface for user service actions, managing user retrieval by ID, email, and fetching all users
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using apekade.Models.Dto;
using apekade.Models.Dto.UserDto;
using apekade.Models.Dto.VendorDto;

namespace apekade.Services;

public interface IUserService
{
    // Method to retrieve a user by their unique ID
    Task<ApiRes> GetUserById(string userId);
    Task<ApiRes> DeactivateAccount(string userId);
    // Method to retrieve a user by their email address
    Task<ApiRes> GetUserByEmail(string email);
    // Method to fetch all registered users
    Task<ApiRes> GetAllUsers();
}
