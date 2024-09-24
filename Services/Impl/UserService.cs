using AutoMapper;
using apekade.Models;
using apekade.Models.Dto;
using apekade.Repositories;
using apekade.Helpers;
using apekade.Services.Impl;

namespace apekade.Services.Impl;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly UserRepository _userRepository;
    private readonly JwtHelper _generateJwtToken;

    public UserService(IMapper mapper, UserRepository userRepository, JwtHelper generateJwtToken)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _generateJwtToken = generateJwtToken;
    }

    public Task<ApiRes> CreateNewUser(string email)
    {
        throw new NotImplementedException();
    }
}