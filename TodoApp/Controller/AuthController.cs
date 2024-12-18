using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.DTOs;
using TodoApp.Services;

namespace TodoApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;


        public AuthController(IAuthService authService , IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Username) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Username and password are required.");
            }

            try
            {
                var token = _authService.Authenticate(loginDto.Username, loginDto.Password);

                if (token == null)
                {
                    return Unauthorized(new { Message = "Invalid credentials" });
                }

                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserCreateDto registerDto)
        {
            if (registerDto == null || string.IsNullOrEmpty(registerDto.Username) || string.IsNullOrEmpty(registerDto.Password))
            {
                return BadRequest("Username and password are required.");
            }

            try
            {
                var result = _userService.CreateUser(registerDto);

                if (result != null)  return Ok(new { Message = "User registered successfully" });

                return  BadRequest(new { Message = "Can't create User" });
               

                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }
    }
}
