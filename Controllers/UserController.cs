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
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("test")]
    public IActionResult CreateUser([FromBody] string email)
    {

        var response = email;
        return Ok(response);
    }

    [HttpGet("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsers();
        return Ok(users);
    }
}