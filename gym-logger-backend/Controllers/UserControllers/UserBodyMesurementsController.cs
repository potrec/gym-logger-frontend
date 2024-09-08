using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gym_logger_backend.Controllers.UserControllers

{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserBodyMesurementsController : ControllerBase
    {
    }
}

