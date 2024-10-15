using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using intervirew_helper_backend.Models;


using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using intervirew_helper_backend.services.IServices;
using InterviewHelper.Business.DTOs;

namespace intervirew_helper_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        /*        public async Task<IActionResult> Register([FromBody] User user)
                {
                    if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.UserPassword))
                    {
                        return BadRequest("Invalid user data.");
                    }

                    if (await _userService.IsUserExist(user.UserName))
                    {
                        return Conflict("User already exists.");
                    }

                    await _userService.AddUser(user);
                    return Ok("User registered successfully.");
                }
        */
        public async Task<IActionResult> Register([FromBody] UserAuth userAuth)
        {
            if (userAuth == null || string.IsNullOrEmpty(userAuth.UserName) || string.IsNullOrEmpty(userAuth.UserPassword))
            {
                return BadRequest("Invalid user data.");
            }

            if (await _userService.IsUserExist(userAuth.UserName))
            {
                return Conflict("User already exists.");
            }

            // Create a User object from the UserAuth DTO
            var user = new User
            {
                UserName = userAuth.UserName,
                UserPassword = userAuth.UserPassword,
                IsActive = true // or set this based on your requirements
            };

            await _userService.AddUser(user);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuth loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.UserPassword))
            {
                return BadRequest("Username and password are required.");
            }
            var user = await _userService.ValidateUser(loginRequest.UserName, loginRequest.UserPassword);
            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            if (!user.IsActive)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new
                {
                    Message = "Your account is not active.",
                    IsActive = user.IsActive
                });
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);
           return Ok(new
            {
                Message = "Login successful.",
                Token = token,
                User = new
                {
                    user.UserId,
                    user.UserName,
                    IsActive = user.IsActive
                }
            });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName)
                // Add additional claims as needed
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["ApiSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
