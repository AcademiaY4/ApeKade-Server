// ------------------------------------------------------------
// File: UserController.cs
// Description: Controller for handling user-related operations
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using apekade.Models.Enums;
using apekade.Services;
using Microsoft.AspNetCore.Authorization;

namespace apekade.Controllers;

[ApiController] 
[Route("api/[controller]")] 
[Authorize] 
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    // Constructor to initialize the UserController with the user service
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // Method to create a user with the provided email
    [HttpPost("test")]
    public IActionResult CreateUser([FromBody] string email)
    {
        var response = email; 
        return Ok(response); 
    }

    // Method to get all users
    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers(); 
        return Ok(users); 
    }
}
