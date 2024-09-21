using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using apekade.Models;

namespace apekade.Helpers;

public class GenerateJwtToken{
    private readonly IConfiguration _configuration;

    public GenerateJwtToken(IConfiguration configuration)
    {
        _configuration = configuration;
    }
     public string GenerateJwt(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        var appSettingToken = _configuration.GetSection("AppSettings:Token").Value;
        if (appSettingToken is null)
            throw new Exception("AppSettings Token is null!");
        
        var key = Encoding.UTF8.GetBytes(appSettingToken);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}