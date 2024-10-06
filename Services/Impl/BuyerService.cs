using System;
using apekade.Enums;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Models.Dto.BuyerDto;
using apekade.Models.Dto.VendorDto;
using apekade.Repositories;
using AutoMapper;

namespace apekade.Services.Impl;

public class BuyerService : IBuyerService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _buyerRepository;

    public BuyerService(IMapper mapper, IUserRepo adminRepository)
    {
        _mapper = mapper;
        _buyerRepository = adminRepository;
    }
    public async Task<ApiRes> AddVendorRating(string id , AddVendorRatingDto addVendorRatingDto)
    {
        try
        {
            var vendor = await _buyerRepository.GetUserByIdAndRole(addVendorRatingDto.VendorId,Role.VENDOR.ToString());
            if (vendor == null) return new ApiRes(404, false, "vendor not found", new { });

            var rating = _mapper.Map<Rating>(addVendorRatingDto);
            vendor.VendorRatings = vendor.VendorRatings ?? new List<Rating>();
            vendor.VendorRatings.Add(rating);
            // Console.WriteLine("pkoo"+rating.Comment);

            await _buyerRepository.AddVendorRating(vendor);
            return new ApiRes(200, true, "rating added", new { });

        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> DeactivateAccount(string userId)
    {
         try
        {
            var user = await _buyerRepository.GetUserById(userId);
            if (user == null) return new ApiRes(404, false, "account not found", new { });

            await _buyerRepository.DeactivateAccount(userId);
            return new ApiRes(200, true, "account deactivated", new { });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }

    public async Task<ApiRes> UpdateAccount(string id,UpdateBuyerDto updateBuyerDto)
    {
        try
        {
            var user = await _buyerRepository.GetUserById(id);
            if (user == null) return new ApiRes(404, false, "account not found", new { });

            _mapper.Map(updateBuyerDto, user);
            await _buyerRepository.UpdateProfile(user);

            var userRes = _mapper.Map<UpdateBuyerResDto>(user);
            return new ApiRes(200, true, "account updated successfully", new { user = userRes });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }
}
