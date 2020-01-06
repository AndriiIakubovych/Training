using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Calendar.Server
{
    public class AuthenticationOptions
    {
        public const string ISSUER = "AuthenticationServer";
        public const string AUDIENCE = "Audience";
        private const string KEY = "secret_key_kinky1006_ghbcwbkkf5981";
        public const int LIFETIME = 60;
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}