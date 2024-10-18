// ------------------------------------------------------------
// File: AuthController.cs
// Description: Controller for handling authentication operations 
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using apekade.Models.Enums;
using apekade.Services;
using apekade.Models.Dto.AuthDto;
using apekade.Models.Dto;
using apekade.Models.Validation;

namespace apekade.Controllers;

[ApiController] 
[Route("api/[controller]")] 
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService; 

    // Constructor to initialize the AuthController with the auth service
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // Method to register a new user
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var validator = new RegisterValidator();
        var result = validator.Validate(registerDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        var response = await _authService.Register(registerDto);
        if (!response.Status)
        {
            return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
        }
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to log in a user
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var validator = new LoginValidator();
        var result = validator.Validate(loginDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        var response = await _authService.Login(loginDto);
        if (!response.Status)
        {
            return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
        }
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }
}
