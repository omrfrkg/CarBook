using System.Security.Cryptography;

namespace CarBook.Application.Tools
{
    public static class JwtKeyGenerator
    {
        public static string GenerateKey(int byteLength = 32)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                var key = new byte[byteLength];
                rng.GetBytes(key);
                return Convert.ToBase64String(key);
            }
        }
    }
}
