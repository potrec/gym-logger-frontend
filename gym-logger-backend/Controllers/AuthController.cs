using BCrypt.Net;
using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using gym_logger_backend.Service;
using gym_logger_backend.Resources;

namespace gym_logger_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly AuthService _authService;

        public AuthController(ApplicationDBContext context, AuthService authService)
        {
            _context = context;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Users.AnyAsync(u => u.UserName == request.UserName || u.Email == request.Email))
            {
                return BadRequest("Username or email already exists");
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User user = new User
            {
                UserName = request.UserName,
                PasswordHash = passwordHash,
                Email = request.Email,
                UserDetails = new UserDetails
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Gender = request.Gender,
                    Status = 1,
                }
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            string token = _authService.CreateToken(user);

            return CreatedAtAction(nameof(Register), new { id = user.Id }, new { token });
        }

        [HttpPost("login")]
        public IActionResult Login(UserDto request)
        {
            User user = _context.Users.FirstOrDefault(u => u.UserName == request.UserName);
            if (user == null)
            {
                return new DefaultResponse<string>("data", false, 404, "User not found").GetData();
            }
            if (BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                string token = _authService.CreateToken(user);
                return new DefaultResponse<string>(token, false, 200, "Login successful").GetData();
            }
            return new DefaultResponse<string>("data", false, 401, "Invalid password").GetData();
        }

    }
}
