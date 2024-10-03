using System;
using apekade.Models.Dto;
using apekade.Models.Dto.VendorDto;

namespace apekade.Services;

public interface IVendorService
{
    // Task<ApiRes> GetVendorProducts(string vendorId);
    Task<ApiRes> UpdateVendorProfile(string Id, UpdateVendorDto updateVendorDto);
}
