using Designer.BLL.Configurations;
using Designer.BLL.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Designer.BLL.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfiguration _config;
        private readonly JwtSecurityTokenHandler _tokenHandler;

        public JwtService(JwtConfiguration config, JwtSecurityTokenHandler tokenHandler)
        {
            _config = config;
            _tokenHandler = tokenHandler;
        }

        public string CreateToken(int id, string email, string role)
        {
            Console.WriteLine("JwtService.CreateToken(int id, string email, UserRole role).start");

            string identifier = id.ToString();
            DateTime now = DateTime.Now;
            JwtSecurityToken token = new(
                _config.Issuer,
                _config.Audience,
                CreateClaims(identifier, email, role),
                now,
                now.AddSeconds(_config.LifeTime),
                CreateCredentials()
            );
            Console.WriteLine("JwtService.CreateToken(int id, string email, UserRole role).end");
            return _tokenHandler.WriteToken(token);
        }

        private SigningCredentials CreateCredentials()
        {
            return new SigningCredentials(CreateKey(), SecurityAlgorithms.HmacSha256);
        }

        private SecurityKey CreateKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Signature));
        }

        private IEnumerable<Claim> CreateClaims(string identifier, string email, string role)
        {
            yield return new Claim(ClaimTypes.NameIdentifier, identifier);
            yield return new Claim(ClaimTypes.Role, role);
            yield return new Claim(ClaimTypes.Email, email);
        }
    }
}
