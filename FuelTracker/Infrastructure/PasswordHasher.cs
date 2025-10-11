using System.Security.Cryptography;

namespace FuelTracker.Application.Identity;

public static class PasswordHasher
{
    public static void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        using var rng = RandomNumberGenerator.Create();
        salt = new byte[16];
        rng.GetBytes(salt);

        hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100_000, HashAlgorithmName.SHA256, 32);
    }

    public static bool VerifyPassword(string password, byte[] hash, byte[] salt)
    {
        var computed = Rfc2898DeriveBytes.Pbkdf2(password, salt, 100_000, HashAlgorithmName.SHA256, 32);
        return CryptographicOperations.FixedTimeEquals(computed, hash);
    }
}