using gym_logger_backend.Data;
using gym_logger_backend.Models.User;
using Microsoft.AspNetCore.Mvc;
using gym_logger_backend.Service;
using gym_logger_backend.Resources;
using gym_logger_backend.Dto.User;
using gym_logger_backend.Validators.User;
using gym_logger_backend.Repository;
using Microsoft.AspNetCore.Mvc.Routing;
using FluentValidation;

namespace gym_logger_backend.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly AuthService _authService;
        private readonly UserLoginValidator _userloginValidator;
        private readonly UserRegisterValidator _userRegisterValidator;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ApplicationDBContext context, AuthService authService, UserLoginValidator userLoginValidator, IUserRepository userRepository, ILogger<AuthController> logger, UserRegisterValidator userRegisterValidator)
        {
            _context = context;
            _authService = authService;
            _userloginValidator = userLoginValidator;
            _userRepository = userRepository;
            _logger = logger;
            _userRegisterValidator = userRegisterValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            var validationResult = await _userRegisterValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errorDictionary = validationResult.Errors.ToDictionary(e => e.PropertyName, e => new[] { e.ErrorMessage });
                return new DefaultResponse<Dictionary<string, string[]>>(errorDictionary, false, 400, "Validation failed").GetData();
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
            var validationResult = await _userloginValidator.ValidateAsync(request);
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
