using System;
using apekade.Enums;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Models.Dto.VendorDto;
using apekade.Repositories;
using AutoMapper;

namespace apekade.Services.Impl;

public class VendorService : IVendorService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _vendorRepository;

    public VendorService(IMapper mapper, IUserRepo vendorRepository)
    {
        _mapper = mapper;
        _vendorRepository = vendorRepository;
    }

    public async Task<ApiRes> UpdateVendorProfile(string Id,UpdateVendorDto updateVendorDto)
    {
        try
        {
            var user = await _vendorRepository.GetUserByIdAndRole(Id,Role.VENDOR.ToString());
            if (user == null) return new ApiRes(409, false, "Vendor already exists.", new { });

           _mapper.Map(updateVendorDto, user);
            await _vendorRepository.UpdateProfile(user);

            var vendorRes = _mapper.Map<UpdateVendorResDto>(user);
            return new ApiRes(200, true, "Vendor updated successfully", new {vendor = vendorRes });
        }
        catch (Exception ex)
        {
            return new ApiRes(500, false, ex.Message, new { });
        }
    }
}
