using gym_logger_backend.Dto.User;
using gym_logger_backend.Models.User;
using gym_logger_backend.Repository;
using gym_logger_backend.Resources;
using gym_logger_backend.Validators.User;
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
        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userRepository.GetAuthUser(User);

            if (user == null)
            {
                return new DefaultResponse<string>("User not found", false, 404, "User not found").GetData();
            }

            var userDto = UserProfileDto.FromUser(user);

            return new DefaultResponse<UserProfileDto>(userDto, true, 200, "User found").GetData();
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateProfile(UserProfileDto request) 
        {
            var validationResult = await new UserProfileValidator().ValidateAsync(request);
            if (!validationResult.IsValid) {
                return new DefaultResponse<string>("Validation failed", false, 400, "Validation failed").GetData();
            }

            var user = await _userRepository.GetAuthUser(User);
            if (user == null) {
                return new DefaultResponse<string>("User not found", false, 404, "User not found").GetData();
            }
            // Update user from request
            user.UserName = request.UserName;
            user.Email = request.Email;
            user.UserDetails.FirstName = request.UserDetails.FirstName;
            user.UserDetails.LastName = request.UserDetails.LastName;
            user.UserDetails.DateOfBirth = request.UserDetails.DateOfBirth;
            //....
        }
    }
}
