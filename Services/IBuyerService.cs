using System;
using apekade.Models.Dto;
using apekade.Models.Dto.BuyerDto;
using apekade.Models.Dto.VendorDto;

namespace apekade.Services;

public interface IBuyerService
{
    Task<ApiRes> AddVendorRating(string Id , AddVendorRatingDto addVendorRatingDto);
    Task<ApiRes> DeactivateAccount(string userId);
    Task<ApiRes> UpdateAccount(string Id ,UpdateBuyerDto updateBuyerDto);
}
