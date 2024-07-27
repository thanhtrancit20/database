using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.DTO.Request;
using WebApplication1.Services.implement;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            var response = _authService.Authenticate(loginRequest);
            if (response.Token == null)
            {
                return Unauthorized(response.Message);
            }
            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                var result = _authService.CreateUser(createUserRequest);
                if (!result)
                {
                    return BadRequest("Email already exists.");
                }
                return Ok("User created successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("parse-token")]
        public IActionResult ParseToken([FromBody] string token)
        {
            try
            {
                var user = _authService.ParseToken(token);

                return Ok(new
                {
                    user.UserId,
                    user.EmailAddress,
                    user.AvatarPath
                });
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
