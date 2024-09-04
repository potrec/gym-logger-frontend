using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gym_logger_backend.Service;
using gym_logger_backend.Resources;
using gym_logger_backend.Dto.User;
using gym_logger_backend.Validators.User;
using gym_logger_backend.Repository;

namespace gym_logger_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly AuthService _authService;
        private readonly UserLoginValidator _userValidator;
        private readonly IUserRepository _userRepository;

        public AuthController(ApplicationDBContext context, AuthService authService, UserLoginValidator userValidator, IUserRepository userRepository)
        {
            _context = context;
            _authService = authService;
            _userValidator = userValidator;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            var validationResult = await _userValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            User user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return new DefaultResponse<string>("data", false, 404, "User not found").GetData();
            }

            if (_userRepository.IsPasswordCorrect(request.Password, user))
            {
                string token = _authService.CreateToken(user);
                return new DefaultResponse<string>(token, false, 200, "Login successful").GetData();
            }
            return new DefaultResponse<string>("data", false, 401, "Invalid password").GetData();
        }

    }
}
