using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using Microsoft.AspNetCore.Mvc;
using gym_logger_backend.Service;
using gym_logger_backend.Resources;
using gym_logger_backend.Dto.User;
using gym_logger_backend.Validators.User;
using gym_logger_backend.Repository;
using Microsoft.AspNetCore.Mvc.Routing;

namespace gym_logger_backend.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly AuthService _authService;
        private readonly UserLoginValidator _userValidator;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ApplicationDBContext context, AuthService authService, UserLoginValidator userValidator, IUserRepository userRepository, ILogger<AuthController> logger)
        {
            _context = context;
            _authService = authService;
            _userValidator = userValidator;
            _userRepository = userRepository;
            _logger = logger;
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
                var errorDictionary = validationResult.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage });
                return new DefaultResponse<Dictionary<string, string[]>>(errorDictionary, false, 400, "Validation failed").GetData();
            }

            User user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
            {
                return new DefaultResponse<string>("User not found", false, 404, "User not found").GetData();
            }

            if (_userRepository.IsPasswordCorrect(request.Password, user))
            {
                string token = _authService.CreateToken(user);
                return new DefaultResponse<string>(token, true, 200, "Login successful").GetData();
            }
            return new DefaultResponse<string>("Invalid password", false, 401, "Invalid password").GetData();
        }

    }
}
