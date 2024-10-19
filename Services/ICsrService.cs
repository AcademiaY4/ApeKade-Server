// ------------------------------------------------------------
// File: ICsrService.cs
// Description: Interface for customer service representative (CSR) actions, managing user account approvals and status changes
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;

namespace apekade.Services;

public interface ICsrService
{
    // Method to approve a user account
    Task<ApiRes> ApproveUserAccount(string UserId);

    // Method to deactivate a user account
    Task<ApiRes> DeactivateUserAccount(string UserId);

    // Method to reactivate a user account
    Task<ApiRes> ReactivateUserAccount(string UserId);
}
