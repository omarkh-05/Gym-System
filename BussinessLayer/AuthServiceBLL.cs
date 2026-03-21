using Entities;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer
{

    public interface IAuthService
    {
        Task<TokenResponse> LoginAsync(LoginRequest request);
        Task RegisterAsync(RegisterRequest request);
        Task<TokenResponse> RefreshAsync(string refreshToken, string phoneNumber);
        Task<bool> LogoutAsync(string refreshToken, LogoutRequest request);
    }

    public class AuthServiceBLL : IAuthService
    {
        private readonly IPersonBLL _personBLL;

        public AuthServiceBLL(IPersonBLL personBLL)
        {
            _personBLL = personBLL;
        }

        // ================= LOGIN =================
        public async Task<TokenResponse> LoginAsync(LoginRequest request)
        {
            var sub = await _personBLL.GetPersonByPhone(request.PhoneNumber);

            if (sub == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, sub.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            // توليد التوكن المزيف
            var accessToken = GenerateFakeAccessToken(sub);
            var refreshToken = GenerateRefreshToken();

            sub.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(refreshToken);
            sub.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);
            sub.RefreshTokenRevokedAt = null;

            await _personBLL.UpdateAuth(sub);

            return new TokenResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        // ================= REFRESH =================
        public async Task<TokenResponse> RefreshAsync(string refreshToken, string phoneNumber)
        {
            var sub = await _personBLL.GetPersonByPhone(phoneNumber);

            if (sub == null)
                throw new UnauthorizedAccessException();

            if (sub.RefreshTokenRevokedAt != null || sub.RefreshTokenExpiresAt <= DateTime.UtcNow)
                throw new UnauthorizedAccessException();

            if (!BCrypt.Net.BCrypt.Verify(refreshToken, sub.RefreshTokenHash))
                throw new UnauthorizedAccessException("Invalid token");

            var newAccess = GenerateFakeAccessToken(sub); // توكن جديد مزيف
            var newRefresh = GenerateRefreshToken();

            sub.RefreshTokenHash = BCrypt.Net.BCrypt.HashPassword(newRefresh);
            sub.RefreshTokenExpiresAt = DateTime.UtcNow.AddDays(7);

            await _personBLL.UpdateAuth(sub);

            return new TokenResponse
            {
                AccessToken = newAccess,
                RefreshToken = newRefresh
            };
        }

        // ================= LOGOUT =================
        public async Task<bool> LogoutAsync(string refreshToken, LogoutRequest request)
        {
            var sub = await _personBLL.GetPersonByPhone(request.PhoneNumber);

            if (sub == null || sub.RefreshTokenHash == null)
                return false;

            if (!BCrypt.Net.BCrypt.Verify(refreshToken, sub.RefreshTokenHash))
                return false;

            sub.RefreshTokenRevokedAt = DateTime.UtcNow;
            return await _personBLL.UpdateAuth(sub);
        }

        // ================= REGISTER =================
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

        // ================= Fake Access Token =================
        private string GenerateFakeAccessToken(Person sub)
        {
            // أي نص عشوائي كتوكن مؤقت
            var token = Guid.NewGuid().ToString() + "-" + sub.PersonID;
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(token));
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

