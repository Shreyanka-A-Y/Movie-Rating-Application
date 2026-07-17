using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interface;
using MovieRating.Commons.DTOs;
using System.Security.Claims;

namespace MovieRating.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDto)
        {
            try
            {
                var token = _authService.isLoginSuccessful(loginDto.Username!, loginDto.Password!);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Expires = DateTime.UtcNow.AddHours(1)
                };
                Response.Cookies.Append("accessToken", token, cookieOptions);

                return Ok(new
                {
                    message = "Login Successful"
                });
            }catch(Exception e)
            {
                return Unauthorized(new
                {
                    message = e.Message
                });
            }
        }

        [Authorize]
        [HttpGet("currentUser")]
        public IActionResult UserDetail()
        {
            return Ok(new
            {
                Username = User.Identity?.Name,
                Role = User.FindFirst(ClaimTypes.Role)?.Value
            });

        }
    }
}
