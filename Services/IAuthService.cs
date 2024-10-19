// ------------------------------------------------------------
// File: IAuthService.cs
// Description: Interface for authentication services, managing user registration and login
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using apekade.Models.Dto;
using apekade.Models.Dto.AuthDto;

namespace apekade.Services;

public interface IAuthService
{
    // Method to register a new user
    Task<ApiRes> Register(RegisterDto registerDto);

    // Method to log in an existing user
    Task<ApiRes> Login(LoginDto loginDto);
}
