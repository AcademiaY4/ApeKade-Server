using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
namespace apekade.Helpers;

public class HashPassword
{
    public static string CreatePasswordHash(string password)
    {
        var salt = new byte[16];
        RandomNumberGenerator.Fill(salt); 

        var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return Convert.ToBase64String(salt) + ":" + hashed;
    }

    public static bool VerifyPasswordHash(string hashedPassword, string password)
    {
        var parts = hashedPassword.Split(':');
        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = parts[1];

        var hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        return hash == storedHash;
    }
}