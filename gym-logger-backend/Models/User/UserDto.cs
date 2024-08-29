namespace gym_logger_backend.Models.User
{
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
