using gym_logger_backend.Models.User;
using gym_logger_backend.Repository;
using gym_logger_backend.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gym_logger_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok("profile");
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsersAsync();
            return new DefaultResponse<List<User>>(users, false, 200, "Login successful").GetData();
        }
    }
}
