using BussinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace GymSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        [EnableRateLimiting("AuthLimiter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrEmpty(request.Password))
                    return BadRequest("credentials are required");

                var result = await _authService.LoginAsync(request);


                Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // in production it must be true
                    SameSite = SameSiteMode.None, // in production it must be SameSiteMode.Strict - مهم عند cross-origin (127.0.0.1:5500 → localhost:7018)
                    Expires = DateTime.UtcNow.AddDays(7),
                    Path = "/"
                });

                return Ok(result);
            }
            catch (UnauthorizedAccessException)
            {
                return NotFound("Invalid credentials");
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
                {
                    return BadRequest("Invalid registration data");
                }
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
        public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.PhoneNumber))
                    return BadRequest("Phone number is required");

                // اقرأ refresh token من HttpOnly cookie
                if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
                    throw new UnauthorizedAccessException("Refresh token missing");

                var result = await _authService.RefreshAsync(refreshToken, request.PhoneNumber);

                // ضع refresh token الجديد في HttpOnly cookie
                Response.Cookies.Append("refreshToken", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // in production it must be true
                    SameSite = SameSiteMode.None, // in production it must be SameSiteMode.Strict - مهم عند cross-origin (127.0.0.1:5500 → localhost:7018)
                    Expires = DateTime.UtcNow.AddDays(7),
                    Path = "/"
                });

                return Ok(new { AccessToken = result.AccessToken });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }


        [HttpPost("Logout")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            if (string.IsNullOrEmpty(request.PhoneNumber))
                return BadRequest("Phone number is required");

            if (!Request.Cookies.TryGetValue("refreshToken", out var refreshToken))
                throw new UnauthorizedAccessException("Refresh token missing");

            if (await _authService.LogoutAsync(refreshToken, request))
            {
                Response.Cookies.Delete("refreshToken");
                return Ok("Logged out successfully");
            }

            return BadRequest("Logout Error Try Again");
        }

    }
}

