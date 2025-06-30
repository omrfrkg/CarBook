using System.Security.Cryptography;

namespace CarBook.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string IssuerSigningKey = "CarBook+*010203CARBOOK01+*..020304CarBookProje";
        public const int Expire = 3; // 3 dakikalık sınırlama

    }
}
