using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using apekade.Models;

namespace apekade.Helpers;

public class JwtHelper
{
    private readonly IConfiguration _configuration;

    public JwtHelper(IConfiguration configuration)
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
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public ClaimsPrincipal? ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var appSettingToken = _configuration.GetSection("AppSettings:Token").Value;
        if (appSettingToken is null)
            throw new Exception("AppSettings Token is null!");
        var key = Encoding.UTF8.GetBytes(appSettingToken);

        try
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero // Remove delay of token when expire
            };

            // Validate the token and return the claims principal
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
            return principal; // Return the ClaimsPrincipal
        }
        catch (Exception)
        {
            // Token is invalid
            return null;
        }
    }


}