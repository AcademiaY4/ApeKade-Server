using System;
using apekade.Helpers;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Models.Dto.AuthDto;
using apekade.Models.Dto.UserDto;
using apekade.Repositories;
using AutoMapper;

namespace apekade.Services.Impl;

public class AdminService : IAdminService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _adminRepository;

    public AdminService(IMapper mapper, IUserRepo adminRepository)
    {
        _mapper = mapper;
        _adminRepository = adminRepository;
    }

    public async Task<ApiRes> ChangePwdWoChk(string userId, ChangePwdWoChkDto changePwdWoChkDto)
    {
        try
        {
            // Fetch the user by userId
            var user = await _adminRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            // Hash the new password
            var newPasswordHash = HashPassword.CreatePasswordHash(changePwdWoChkDto.NewPassword);
            user.PasswordHash = newPasswordHash;

            // Update the user's password in the repository
            await _adminRepository.UpdateProfile(user);

            return new ApiRes(200, true, "Password changed successfully.", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> ChangeUserPassword(string userId, ChangePasswordDto changePasswordDto)
    {
        try
        {
            // Fetch the user by userId
            var user = await _adminRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            // Check if the current password matches
            if (!HashPassword.VerifyPasswordHash(user.PasswordHash, changePasswordDto.OldPassword))
            {
                return new ApiRes(403, false, "Password incorrect", new { });
            }

            // Hash the new password
            var newPasswordHash = HashPassword.CreatePasswordHash(changePasswordDto.NewPassword);
            user.PasswordHash = newPasswordHash;

            // Update the user's password in the repository
            await _adminRepository.UpdateProfile(user);

            return new ApiRes(200, true, "Password changed successfully.", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> CreateUser(CreateUserDto createUserDto)
    {
        try
        {
            var existingUser = await _adminRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser != null) return new ApiRes(409, false, "User already exists.", new { });

            var newUser = _mapper.Map<User>(createUserDto);
            // auto activate account when admin create users
            newUser.IsApproved = true;
            newUser.Status= Models.Enums.Status.ACTIVE;

            await _adminRepository.CreateNewUser(newUser);
            return new ApiRes(201, true, "User created successfully", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> DeactivateUser(string userId)
    {
        try
        {
            var user = await _adminRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            await _adminRepository.DeactivateAccount(userId);
            return new ApiRes(200, true, "User deactivated", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> DeleteUser(string userId)
    {
        try
        {
            var user = await _adminRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            await _adminRepository.DeleteUser(userId);
            return new ApiRes(200, true, "User deleted", new { });

        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> GetAllUsers()
    {
        try
        {
            var users = await _adminRepository.GetAllUsers();
            var userResDto = _mapper.Map<List<GetUserResDto>>(users);

            // Calculate user counts
            var activeCount = users.Count(u => u.Status == Models.Enums.Status.ACTIVE);
            var pendingCount = users.Count(u => u.Status == Models.Enums.Status.PENDING);
            var deactivatedCount = users.Count(u => u.Status == Models.Enums.Status.DEACTIVATED);
            var totalUsers = users.Count;

            return new ApiRes(200, true, "Users fethed", new
            {
                users = userResDto,
                activeUsers = activeCount,
                pendingUsers = pendingCount,
                deactiveUsers = deactivatedCount,
                totalUsers
            });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> GetUserByEmail(string email)
    {
        try
        {
            var user = await _adminRepository.GetUserById(email);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            var userRes = _mapper.Map<GetUserResDto>(user);
            return new ApiRes(200, true, "User found", new { user = userRes });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> GetUserById(string userId)
    {
        try
        {
            var user = await _adminRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            var userRes = _mapper.Map<GetUserResDto>(user);
            return new ApiRes(200, true, "User found", new { user = userRes });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> ReactivateUser(string userId)
    {
        try
        {
            var user = await _adminRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            await _adminRepository.ReactivateAccount(userId);
            return new ApiRes(200, true, "User reactivated", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> UpdateUser(string id, UpdateUserDto updateUserDto)
    {
        try
        {
            var user = await _adminRepository.GetUserById(id);
            if (user == null) return new ApiRes(404, false, "User not found", new { });

            _mapper.Map(updateUserDto, user);
            await _adminRepository.UpdateProfile(user);

            var userRes = _mapper.Map<UpdateUserResDto>(user);
            return new ApiRes(200, true, "User updated successfully", new { user = userRes });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }
}
