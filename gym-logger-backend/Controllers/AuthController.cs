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

namespace gym_logger_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static User user = new ();
        private readonly IConfiguration _config;
        private readonly ApplicationDBContext _context;

        public AuthController(IConfiguration config, ApplicationDBContext context)
        {
            _config = config;
            _context = context;
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

            string token = CreateToken(user);

            return CreatedAtAction(nameof(Register), new { id = user.Id}, new {token} );
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                string token = CreateToken(user);
                return Ok(token);
            }

            return Unauthorized();
        }


        private string CreateToken(User user) 
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}
