﻿using BCrypt.Net;
using gym_logger_backend.Models.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace gym_logger_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;

            return Ok(user);
        }
    }
}
