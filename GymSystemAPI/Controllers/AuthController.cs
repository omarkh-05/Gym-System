using BussinessLayer;
using GymSystemAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace GymSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly AccessToken _accessToken;
        readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, AccessToken accessToken, ILogger<AuthController> logger)
        {
            _authService = authService;
            _accessToken = accessToken;
            _logger = logger;
        }

        [HttpPost("Login")]
        [EnableRateLimiting("AuthLimiter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.Password))
                    return BadRequest("credentials are required");

                var result = await _authService.LoginAsync(request);
                var accessToken = _accessToken.GenerateAccessToken(result.User);

                Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // if we use https we use true
                    SameSite = SameSiteMode.None, // because we use http
                    Expires = DateTime.UtcNow.AddDays(7),
                    Path = "/"
                });

                Response.Cookies.Append("accessToken", accessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // خليها true في production
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    Path = "/"
                });

                return Ok();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("Invalid credentials");
            }
        }

        [HttpPost("Register")]
        [EnableRateLimiting("AuthLimiter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest("Invalid registration data");

                await _authService.RegisterAsync(request);
                return Ok(new { message = "User registered successfully" });
            }
            catch (UnauthorizedAccessException)
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpPost("Refresh")]
        [EnableRateLimiting("AuthLimiter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Refresh()
        {
            try
            {
               if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
                   throw new UnauthorizedAccessException("Refresh token missing");

                var result = await _authService.RefreshAsync(refreshToken);
                var newAccessToken = _accessToken.GenerateAccessToken(result.User);

                Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddDays(7),
                    Path = "/"
                });

                Response.Cookies.Append("accessToken", newAccessToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    Path = "/"
                });

                return Ok();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout()
        {
            if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
                return NotFound("Refresh token missing");

            if (await _authService.LogoutAsync(refreshToken))
            {
                Response.Cookies.Delete("refreshToken");
                Response.Cookies.Delete("accessToken");
                return Ok("Logged out successfully");
            }

            return BadRequest("Logout Error Try Again");
        }

        [HttpGet("CheckAuth")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult CheckAuth()
        {
            var phoneNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value;
            if (string.IsNullOrEmpty(phoneNumber))
                return Unauthorized("Invalid token");;

            return Ok();
        }

    }
}