using apekade.Models.Dto;
using apekade.Repositories;
using apekade.Helpers;
using apekade.Services.Impl;
using AutoMapper;
using apekade.Models.Dto.AuthDto;
using apekade.Models;

namespace apekade.Services.Impl;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IUserRepo _userRepository;
    private readonly JwtHelper _jwtHelper;

    public AuthService(IMapper mapper, IUserRepo userRepository, JwtHelper jwtHelper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _jwtHelper = jwtHelper;
    }
    public async Task<ApiRes> Login(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByEmailAndRole(loginDto.Email,loginDto.Role);
        if (user == null)
        {
            return new ApiRes(404, false, "user not found", new { });
        }
       if (!HashPassword.VerifyPasswordHash(user.PasswordHash, loginDto.Password))
        {
            return new ApiRes(403, false, "Password incorrect", new { });
        }

        var loginResDto = _mapper.Map<LoginResDto>(user);

        var token = _jwtHelper.GenerateJwt(user);
        return new ApiRes(200, true, "login succcess", new { access_token=token ,user=loginResDto,role=loginResDto.Role});
    }

    public async Task<ApiRes> Register(RegisterDto registerDto)
    {
        try
        {
            //check if the user exists in the DB
            var existingUser = await _userRepository.GetUserByEmail(registerDto.Email);
            if (existingUser != null)
            {
                return new ApiRes(
                    409,
                    false,
                    "User already exists.",
                    new { }
                );
            }
            var newUser = _mapper.Map<User>(registerDto);
            newUser.PasswordHash = HashPassword.CreatePasswordHash(registerDto.Password);
            await _userRepository.CreateNewUser(newUser);
            var token = _jwtHelper.GenerateJwt(newUser);
            var userResponse = _mapper.Map<RegisterResDto>(newUser);

            return new ApiRes(
                201,
                true,
                "User created successfully!",
                new { access_token=token,user=userResponse }
            );
        }
        catch (Exception ex)
        {
            return new ApiRes(
                500,
                false,
                ex.Message,
                new { }
            );
        }
    }
}