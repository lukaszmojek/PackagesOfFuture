using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Api.Services
{
    public class UserService : IUserService
    {
        // private readonly AppSettings _appSettings;

        public UserService()//IOptions<AppSettings> appSettings)
        {
            // _appSettings = appSettings.Value;
        }

        public string Authenticate(User user)
        {
            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return token;
        }

        private string GenerateJwtToken(User user)
        {
            // var claimsAndRoles = new Dictionary<string, object>();
            // claimsAndRoles.Add("claims", new Dictionary<string, string>{{"hasAccessToManager", "no"}});
            var tokenHandler = new JwtSecurityTokenHandler();
            //TODO: Move that 'secret' to appsettings and change it
            var key = Encoding.ASCII.GetBytes("dupa123asdfasdgasdffasdasdfghasdfasdfasdwfawefasdv");//_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()), 
                    new Claim("role", user.Type.ToString())
                }),
                // Claims = claimsAndRoles,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                    )
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}