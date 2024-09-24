using apekade.Models.Dto;
using apekade.Models.Dto.AuthDto;

namespace apekade.Services;

public interface IAuthService{
    Task<ApiRes> Register(RegisterDto registerDto);
    Task<ApiRes> Login(LoginDto loginDto);
}