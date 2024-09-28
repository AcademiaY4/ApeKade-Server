using apekade.Models.Dto;
using apekade.Models.Dto.UserDto;
using apekade.Models.Validation;
using apekade.Models.Validation.UserValidation;
using apekade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace apekade.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "ADMIN")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("create-user")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var validator = new CreateUserValidator();
        var result = validator.Validate(createUserDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        var response = await _adminService.CreateUser(createUserDto);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpPut("update-user/{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUserDto updateUserDto)
    {
        // Validate the ID
        if (!ObjectId.TryParse(id, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var validator = new UpdateUserValidator();
        var result = validator.Validate(updateUserDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        var response = await _adminService.UpdateUser(id, updateUserDto);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpPost("deactivate-user/{userId}")]
    public async Task<IActionResult> DeactivateUser(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _adminService.DeactivateUser(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpPost("reactivate-user/{userId}")]
    public async Task<IActionResult> ReactivateUser(string userId)
    {
        var response = await _adminService.ReactivateUser(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpDelete("delete-user/{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _adminService.DeleteUser(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);
        var response = await _adminService.GetUserById(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpGet("all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _adminService.GetAllUsers();
        return Ok(users);
    }
}

