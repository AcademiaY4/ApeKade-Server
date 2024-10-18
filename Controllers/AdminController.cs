// ------------------------------------------------------------
// File: AdminController.cs
// Description: This file contains the AdminController class,
//              which manages user-related actions for admin users.
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

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

    // Constructor to initialize the AdminService
    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    // Method to create a new user
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

    // Method to update an existing user by ID
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

    // Method to deactivate a user by ID
    [HttpGet("deactivate-user/{userId}")]
    public async Task<IActionResult> DeactivateUser(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _adminService.DeactivateUser(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to activate a user by ID
    [HttpGet("activate-user/{userId}")]
    public async Task<IActionResult> ActivateUser(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _adminService.ReactivateUser(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to delete a user by ID
    [HttpDelete("delete-user/{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _adminService.DeleteUser(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to get a user by ID
    [HttpGet("get-user/{userId}")]
    public async Task<IActionResult> GetUserById(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);
        var response = await _adminService.GetUserById(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to get all users
    [HttpGet("all-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _adminService.GetAllUsers();
        return Ok(users);
    }

    // Method to change a user's password
    [HttpPut("change-password/{userId}")]
    public async Task<IActionResult> ChangePassword(string userId, [FromBody] ChangePasswordDto changePasswordDto)
    {
        // Validate the MongoDB ObjectId
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "Invalid MongoDB ObjectId.", null);

        // Validate the ChangePasswordDto using FluentValidation or any other validation logic
        var validator = new ChangePasswordValidator();
        var result = validator.Validate(changePasswordDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        // Call the service to change the password
        var response = await _adminService.ChangeUserPassword(userId, changePasswordDto);

        // Return the response from the service
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to change a user's password without checking
    [HttpPut("change-password-without-check/{userId}")]
    public async Task<IActionResult> ChangePasswordWithoutCheck(string userId, [FromBody] ChangePwdWoChkDto changePasswordDto)
    {
        // Validate the MongoDB ObjectId
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "Invalid MongoDB ObjectId.", null);

        // Validate the ChangePasswordDto using FluentValidation or any other validation logic
        var validator = new ChangePwdWoChkValidator();
        var result = validator.Validate(changePasswordDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        // Call the service to change the password
        var response = await _adminService.ChangePwdWoChk(userId, changePasswordDto);

        // Return the response from the service
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }
}
