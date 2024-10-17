// ------------------------------------------------------------
// File: CsrService.cs
// Description: Implements services for managing customer accounts, including approving, deactivating, and reactivating user accounts.
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;
using apekade.Repositories;
using AutoMapper;

namespace apekade.Services.Impl;

public class CsrService : ICsrService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _csrRepository;

    public CsrService(IMapper mapper, IUserRepo csrRepository)
    {
        _mapper = mapper;
        _csrRepository = csrRepository;
    }

    // Method to approve a user account
    public async Task<ApiRes> ApproveUserAccount(string UserId)
    {
        try
        {
            var customer = await _csrRepository.GetUserById(UserId);
            if (customer == null)
            {
                return new ApiRes(404, false, "User not found", new { });
            }

            await _csrRepository.ApproveUserAccount(UserId);
            return new ApiRes(200, true, "User account approved", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    // Method to deactivate a user account
    public async Task<ApiRes> DeactivateUserAccount(string UserId)
    {
        try
        {
            var customer = await _csrRepository.GetUserById(UserId);
            if (customer == null)
            {
                return new ApiRes(404, false, "Customer not found", new { });
            }

            await _csrRepository.DeactivateAccount(UserId);
            return new ApiRes(200, true, "Customer account deactivated", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    // Method to reactivate a user account
    public async Task<ApiRes> ReactivateUserAccount(string UserId)
    {
        try
        {
            var customer = await _csrRepository.GetUserById(UserId);
            if (customer == null)
            {
                return new ApiRes(404, false, "Customer not found", new { });
            }

            await _csrRepository.ReactivateAccount(UserId);
            return new ApiRes(200, true, "Customer account reactivated", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }
}
