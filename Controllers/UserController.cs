using Microsoft.AspNetCore.Mvc;
using apekade.Models.Enums;
using apekade.Services;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Bson;
using apekade.Models.Dto;

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

    [HttpGet("deactivate-user/{userId}")]
    public async Task<IActionResult> DeactivateUser(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _userService.DeactivateAccount(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }
}