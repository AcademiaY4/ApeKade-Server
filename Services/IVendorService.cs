// ------------------------------------------------------------
// File: IVendorService.cs
// Description: Interface for vendor service actions, managing vendor profile updates
// Author: Shabeer M.S.M.
// ------------------------------------------------------------

using System;
using apekade.Models.Dto;
using apekade.Models.Dto.VendorDto;

namespace apekade.Services;

public interface IVendorService
{
    // Task<ApiRes> GetVendorProducts(string vendorId);

    // Method to update the vendor's profile with the provided details
    Task<ApiRes> UpdateVendorProfile(string Id, UpdateVendorDto updateVendorDto);

    
}
