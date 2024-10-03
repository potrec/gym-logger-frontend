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
    public class UserBodyMeasurementsController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserBodyMeasurementsController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("create")]
        public async Task<IActionResult> AddBodyMeasurement(UserBodyMeasurement measurement) 
        {
            //todo: add validation
            User user = await _userRepository.GetAuthUser(User);
            if (user == null)
            {
                return new DefaultResponse<string>("User not found", false, 404, "User not found").GetData();
            }
            user.UserBodyMeasurements.Add(measurement);
            await _userRepository.UpdateUserAsync(user);
            return new DefaultResponse<ICollection<UserBodyMeasurement>>(user.UserBodyMeasurements, true, 200, "Add user body measurement").GetData();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserBodyMeasurements()
        {
            //todo: check for short lifetime of the auth token
            User user = await _userRepository.GetAuthUser(User);
            return new DefaultResponse<ICollection<UserBodyMeasurement>>(user.UserBodyMeasurements, true, 200, "User body measurements").GetData();
        }
    }
}

