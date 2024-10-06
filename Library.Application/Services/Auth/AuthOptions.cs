using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "YourIssuer"; // издатель токена
        public const string AUDIENCE = "YourAudience"; // потребитель токена
        private const string KEY = "B5B21C1E6048CC173168CEE073BBE8B7BC63D53C367D1D05686DA0DC538E5654"; // ключ для шифрования
        public const int LIFETIME = 10; // время жизни токена в минутах

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
