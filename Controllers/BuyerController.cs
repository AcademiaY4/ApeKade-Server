// ------------------------------------------------------------
// File: BuyerController.cs
// Description: Controller for handling buyer-related operations
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System.Security.Claims;
using apekade.Models.Dto;
using apekade.Models.Dto.BuyerDto;
using apekade.Models.Dto.VendorDto;
using apekade.Models.Validation.BuyerValidation;
using apekade.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace apekade.Controllers;

[Route("api/[controller]")] 
[ApiController] 
[Authorize(Roles = "BUYER")] 
public class BuyerController : ControllerBase
{
    private readonly IBuyerService _buyerService; 

    // Constructor to initialize the BuyerController with the buyer service
    public BuyerController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

    // Method to update the buyer's account information
    [HttpPut("update-account")]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateBuyerDto updateBuyerDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var validator = new UpdateBuyerValidator();
        var result = validator.Validate(updateBuyerDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        var response = await _buyerService.UpdateAccount(userId, updateBuyerDto);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to deactivate the buyer's account
    [HttpPost("deactivate-account")]
    public async Task<IActionResult> DeactivateAccount()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _buyerService.DeactivateAccount(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to add a rating for a vendor
    [HttpPost("add-vendor-rating")]
    public async Task<IActionResult> AddVendorRating([FromBody] AddVendorRatingDto addVendorRatingDto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var validator = new AddRatingValidator();
        var result = validator.Validate(addVendorRatingDto);

        if (!result.IsValid)
        {
            var firstError = result.Errors.Select(e => new { error = e.ErrorMessage }).FirstOrDefault();
            return this.ApiRes(400, false, "Validation error", firstError);
        }

        addVendorRatingDto.CustomerId = userId;
        var response = await _buyerService.AddVendorRating(addVendorRatingDto);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to get vendor details
    [HttpGet("get-vendor/{vendorId}")]
    public async Task<IActionResult> GetVendorById(string vendorId)
    {
        if (!ObjectId.TryParse(vendorId, out var objectId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);
        var response = await _buyerService.GetVendorById(vendorId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    // Method to get reviews and ratings of current user
    [HttpGet("get-reviews")]
    public async Task<IActionResult> GetReviews()
    {
        
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _buyerService.GetReviews(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }
}
