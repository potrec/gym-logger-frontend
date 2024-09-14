using gym_logger_backend.Dto.User;
using gym_logger_backend.Models.User;
using gym_logger_backend.Repository;
using gym_logger_backend.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return new DefaultResponse<string>("You are unauthorized", false, 401, "You are unauthorized").GetData();
            }

            int userId = int.Parse(userIdClaim.Value);
            var user = await _userRepository.GetUserAsync(userId);

            if (user == null)
            {
                return new DefaultResponse<string>("User not found", false, 404, "User not found").GetData();
            }

            var userDto = new UserProfileDto(user);

            return new DefaultResponse<UserProfileDto>(userDto, true, 200, "User found").GetData();
        }


    }
}
