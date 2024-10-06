using System;
using apekade.Models.Dto;

namespace apekade.Services;

public interface ICsrService
{
    Task<ApiRes> ApproveUserAccount(string UserId);
    Task<ApiRes> DeactivateUserAccount(string UserId);
    Task<ApiRes> ReactivateUserAccount(string UserId);


}
