using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Portify.Application.Interfaces;
using Portify.Infrastructure.Configuration.Settings;

namespace Portify.Domain.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _settings;

    public JwtService(IOptions<JwtSettings> options)
    {
        _settings = options.Value;
    }
        public string GenerateToken(Guid userId, string email, string[] roles)
        {
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
        }
    }
}
