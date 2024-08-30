namespace gym_logger_backend.Models.User
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class UserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required Gender Gender { get; set; }

    }
}
