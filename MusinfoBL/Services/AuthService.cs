using CommonDataAccess.Finder.Interfaces;
using Microsoft.IdentityModel.Tokens;
using MusinfoBL.Services.Interface;
using MusinfoDB.Finders.Interface;
using MusinfoDB.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MusinfoBL.Services
{
    public class AuthService : IAuthService
    {
        private readonly IService<User> _service;
        private readonly ICommonFinder<Role> _finder;

        public AuthService(IService<User> service, ICommonFinder<Role> finder)
        {
            _service = service;
            _finder = finder;
        }

        public string Login(string username, string password)
        {
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                return null;
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _service.FirstOrDefault(x => x.UserName == username && x.Password == password);
            if (user != null)
            {
                var role = _finder.Get(user.RoleId);
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, role.RoleName)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        public string Register(User user)
        {
            var isUsernameExists = _service.Exists(x => x.Email == user.Email);
            if (isUsernameExists)
                return "Username already exsists";

            var isEmailExists = _service.Exists(x => x.Email == user.Email);
            if (isEmailExists)
                return "Email already exsists";

            _service.Create(user);
            return "Success";

        }
    }
}
