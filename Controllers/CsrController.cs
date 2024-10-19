// ------------------------------------------------------------
// File: CsrController.cs
// Description: Controller for handling customer service representative (CSR) operations
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using apekade.Models.Dto;
using apekade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace apekade.Controllers;

[Route("api/[controller]")] 
[ApiController] 
[Authorize(Roles = "CSR,ADMIN")]
public class CsrController : ControllerBase
{
    private readonly ICsrService _csrService;

    // Constructor to initialize the CsrController with the CSR service
    public CsrController(ICsrService csrService)
    {
        _csrService = csrService;
    }

    // Method to approve a customer's account
    [HttpPost("approve-customer/{userId}")]
    public async Task<IActionResult> ApproveCustomerAccount(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _csrService.ApproveUserAccount(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to deactivate a customer's account
    [HttpPost("deactivate-customer/{userId}")]
    public async Task<IActionResult> DeactivateCustomerAccount(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _csrService.DeactivateUserAccount(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to reactivate a customer's account
    [HttpPost("reactivate-customer/{userId}")]
    public async Task<IActionResult> ReactivateCustomerAccount(string userId)
    {
        if (!ObjectId.TryParse(userId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _csrService.ReactivateUserAccount(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }
}
