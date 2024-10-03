using AutoMapper;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Repositories;
using apekade.Helpers;
using apekade.Services.Impl;
using apekade.Models.Dto.VendorDto;
using apekade.Models.Dto.UserDto;

namespace apekade.Services.Impl;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepository;

    public UserService(IMapper mapper, IUserRepo userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }
    public Task<ApiRes> AddVendorRating(AddVendorRatingDto addVendorRatingDto)
    {
        throw new NotImplementedException();
    }

    public Task<ApiRes> DeactivateAccount(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiRes> GetUserByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<ApiRes> GetUserById(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<ApiRes> UpdateAccount(UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }
}