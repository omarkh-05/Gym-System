using Entities;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BussinessLayer
{
    public interface IAuthService
    {
        Task<TokenResponse> LoginAsync(LoginRequest request);
        Task RegisterAsync(RegisterRequest request);
        Task<TokenResponse> RefreshAsync(string refreshToken);
        Task<bool> LogoutAsync(string refreshToken);
    }

    public class AuthServiceBLL : IAuthService
    {
        private readonly IPersonBLL _personBLL;

        public AuthServiceBLL(IPersonBLL personBLL)
        {
            _personBLL = personBLL;
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest request)
        {
            var sub = await _personBLL.GetPersonByPhone(request.PhoneNumber);

            if (sub == null || !BCrypt.Net.BCrypt.Verify(request.Password, sub.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            var refreshTokenId = Guid.NewGuid();
            var refreshToken = GenerateRefreshToken();

            sub.RefreshTokenId = refreshTokenId;
            sub.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
            sub.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            sub.RefreshTokenRevokedAt = null;

            await _personBLL.UpdateAuth(sub);

            return new TokenResponse
            {
                User = sub,
                RefreshToken = $"{refreshTokenId}.{refreshToken}"
            };
        }

        public async Task<TokenResponse> RefreshAsync(string refreshToken)
        {
            var parts = refreshToken.Split('.');
            if (parts.Length != 2)
                throw new UnauthorizedAccessException("Invalid token format");

            if (!Guid.TryParse(parts[0], out Guid tokenId))
                throw new UnauthorizedAccessException("Invalid token 1");

            var secret = parts[1];

            var sub = await _personBLL.GetByRefreshTokenId(tokenId);

            if (sub == null)
                throw new UnauthorizedAccessException("Invalid token 2");

            if (sub.RefreshTokenRevokedAt != null || sub.RefreshTokenExpiresAt <= DateTime.UtcNow)
                throw new UnauthorizedAccessException("Token expired");

            if (!BCrypt.Net.BCrypt.Verify(secret, sub.RefreshTokenHash))
                throw new UnauthorizedAccessException("Invalid token 3");

            // 🔄 Rotation
            var newTokenId = Guid.NewGuid();
            var newSecret = GenerateRefreshToken();

            sub.RefreshTokenId = newTokenId;
            sub.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(newSecret);
            sub.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            sub.RefreshTokenRevokedAt = null;

            await _personBLL.UpdateAuth(sub);

            return new TokenResponse
            {
                User = sub,
                RefreshToken = $"{newTokenId}.{newSecret}"
            };
        }

        public async Task<bool> LogoutAsync(string refreshToken)
        {
            var parts = refreshToken.Split('.');
            if (parts.Length != 2) return false;

            if (!Guid.TryParse(parts[0], out Guid tokenId))
                return false;

            var secret = parts[1];

            var sub = await _personBLL.GetByRefreshTokenId(tokenId);

            if (sub == null || sub.RefreshTokenHash == null)
                return false;

            if (!BCrypt.Net.BCrypt.Verify(secret, sub.RefreshTokenHash))
                return false;

            sub.RefreshTokenRevokedAt = DateTime.UtcNow;

            return await _personBLL.UpdateAuth(sub);
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            var existing = await _personBLL.GetPersonByPhone(request.PhoneNumber);
            if (existing != null) throw new Exception("Phone already exists");

            var person = new Person
            {
                Name = request.FullName,
                PhoneNo = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                NationalNo = request.NationalNo,
                NationalityID = request.NationalityID,
                Address = request.Address,
                HasDisease = request.HasDisease,
                PersonType = request.PersonType
            };

            var id = await _personBLL.RegisterPerson(person);
            if (id <= 0) throw new Exception("Register failed");
        }

        private string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}