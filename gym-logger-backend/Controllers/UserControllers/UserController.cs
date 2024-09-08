using gym_logger_backend.Models.User;
using gym_logger_backend.Repository;
using gym_logger_backend.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gym_logger_backend.Controllers.UserControllers
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
            string userEmail = User.Identity.Name;
            User user = _userRepository.GetUserByEmailAsync(userEmail).Result;

            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }


    }
}
