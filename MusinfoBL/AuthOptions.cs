using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MusinfoBL
{
    public class AuthOptions
    {
        public const string ISSUER = "MusinfoServer";
        public const string AUDIENCE = "MusinfoClient";
        const string KEY = "mylittle_secretkey!83724";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
