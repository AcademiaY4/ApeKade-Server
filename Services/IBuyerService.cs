// ------------------------------------------------------------
// File: IBuyerService.cs
// Description: Interface for buyer services, managing vendor ratings, account deactivation, and account updates
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;
using apekade.Models.Dto.BuyerDto;
using apekade.Models.Dto.VendorDto;

namespace apekade.Services;

public interface IBuyerService
{
    // Method to add a rating for a vendor
    Task<ApiRes> AddVendorRating(AddVendorRatingDto addVendorRatingDto);

    // Method to retrieve a user by their ID
    Task<ApiRes> GetVendorById(string vendorId);
    // Method to retrieve reviews by user ID
    Task<ApiRes> GetReviews(string vendorId);

    // Method to deactivate a buyer's account
    Task<ApiRes> DeactivateAccount(string userId);

    // Method to update buyer account information
    Task<ApiRes> UpdateAccount(string Id, UpdateBuyerDto updateBuyerDto);
}
