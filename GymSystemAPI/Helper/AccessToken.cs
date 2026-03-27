using Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymSystemAPI.Helper
{
    public class AccessToken
    {
        private readonly IConfiguration _config;

        public AccessToken(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateAccessToken(Person person)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, person.PersonID.ToString()),
                new Claim(ClaimTypes.MobilePhone, person.PhoneNo),
                new Claim(ClaimTypes.Role, person.PersonType)
            };

            var secretKey = _config["Gym_JWT_Key"];

            if (string.IsNullOrWhiteSpace(secretKey))
                throw new Exception("JWT secret key is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "GymSystem",
                audience: "GymSubscribers",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
