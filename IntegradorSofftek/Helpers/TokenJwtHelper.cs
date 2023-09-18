using IntegradorSofftek.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IntegradorSofftek.Helpers
{
    public class TokenJwtHelper
    {
        private IConfiguration _configuration;
        public TokenJwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Dni", usuario.Dni.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario.CodUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuario.RolId.ToString()),
            };

            var identity = new ClaimsIdentity(claims, "NombreDeAutenticacion");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: System.DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
