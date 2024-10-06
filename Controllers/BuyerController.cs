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
    public BuyerController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

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

    [HttpPost("deactivate-account")]
    public async Task<IActionResult> DeactivateAccount()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return this.ApiRes(400, false, "invalid MongoDB ObjectId.", null);

        var response = await _buyerService.DeactivateAccount(userId);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }

    [HttpPost("add-vendor-rating")]
    public async Task<IActionResult> AddVendorRating(AddVendorRatingDto addVendorRatingDto)
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

        var response = await _buyerService.AddVendorRating(userId, addVendorRatingDto);
        return this.ApiRes(response.Code, response.Status, response.Message, response.Data);
    }
}

