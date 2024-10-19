// ------------------------------------------------------------
// File: VendorController.cs
// Description: Controller for handling vendor-related operations
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System.Security.Claims;
using apekade.Models.Dto;
using apekade.Models.Dto.VendorDto;
using apekade.Models.Validation.VendorValidation;
using apekade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apekade.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "VENDOR")]
public class VendorController : ControllerBase
{
    private readonly IVendorService _vendorService;

    // Constructor to initialize the VendorController with the vendor service
    public VendorController(IVendorService buyerService)
    {
        _vendorService = buyerService; 
    }

    // Method to update the vendor's account
    [HttpPut("update-account")]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateVendorDto updateVendorDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var validator = new UpdateVendorValidator();
        var result = validator.Validate(updateVendorDto); 

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault(); 
            return this.ApiRes(400, false, "Validation error", firstError); 
        }

        var response = await _vendorService.UpdateVendorProfile(userId, updateVendorDto); 
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data); 
    }
}
