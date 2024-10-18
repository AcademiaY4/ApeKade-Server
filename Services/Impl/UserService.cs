// ------------------------------------------------------------
// File: UserService.cs
// Description: Implements services for managing user accounts, including retrieving user details and handling ratings, account updates, and user statuses.
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using AutoMapper;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Repositories;
using apekade.Helpers;
using apekade.Services.Impl;
using apekade.Models.Dto.VendorDto;
using apekade.Models.Dto.UserDto;
using System;

namespace apekade.Services.Impl;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepository;

    public UserService(IMapper mapper, IUserRepo userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    // Method to add a vendor rating (not implemented)
    public Task<ApiRes> AddVendorRating(AddVendorRatingDto addVendorRatingDto)
    {
        throw new NotImplementedException();
    }

    // Method to deactivate a user account (not implemented)
    public Task<ApiRes> DeactivateAccount(string userId)
    {
        throw new NotImplementedException();
    }

    // Method to get a user by email (not implemented)
    public Task<ApiRes> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    // Method to get a user by ID (not implemented)
    public Task<ApiRes> GetUserById(string userId)
    {
        throw new NotImplementedException();
    }

    // Method to update a user account (not implemented)
    public Task<ApiRes> UpdateAccount(UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }

    // Method to get all users and their counts
    public async Task<ApiRes> GetAllUsers()
    {
        try
        {
            var users = await _userRepository.GetAllUsers();
            var userResDto = _mapper.Map<List<GetUserResDto>>(users);

            // Calculate user counts
            var activeCount = users.Count(u => u.Status == Models.Enums.Status.ACTIVE);
            var pendingCount = users.Count(u => u.Status == Models.Enums.Status.PENDING);
            var deactivatedCount = users.Count(u => u.Status == Models.Enums.Status.DEACTIVATED);
            var totalUsers = users.Count;

            return new ApiRes(200, true, "Users fetched", new
            {
                users = userResDto,
                activeUsers = activeCount,
                pendingUsers = pendingCount,
                deactivatedUsers = deactivatedCount,
                totalUsers
            });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }
}
