using AutoMapper;
using apekade.Models;
using apekade.Dto;
using apekade.Repositories;
using apekade.Helpers;
using apekade.Services.Impl;
using apekade.Dto.UserDto;

namespace apekade.Services.Impl;

public class UserService : IUserService
{
    private readonly IMapper _mapper;

    private readonly UserRepository _userRepository;

    private readonly GenerateJwtToken _generateJwtToken;

    public UserService(IMapper mapper, UserRepository userRepository, GenerateJwtToken generateJwtToken)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _generateJwtToken = generateJwtToken;
    }

    public async Task<ApiRes<UserTokenResDto>> CreateNewUser(UserReqtDto userRequestDto)
    {
        var response = new ApiRes<UserTokenResDto>();

        try
        {
            var newUser = _mapper.Map<User>(userRequestDto);
            HashPassword.CreatePasswordHash(userRequestDto.Password, out var passwordHash, out var passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;

            await _userRepository.save(newUser);

            var token = _generateJwtToken.GenerateJwt(newUser);

            var userResponse = _mapper.Map<UserResDto>(newUser);

            response.Status = true;
            response.Code = 201;
            response.Data = new UserTokenResDto { User = userResponse, Token = token };
            response.Message = "User created successfully!";
        }
        catch (Exception ex)
        {
            response.Status = false;
            response.Code = 500;
            response.Message = ex.Message;
        }

        return response;
    }
}