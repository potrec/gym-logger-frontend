namespace gym_logger_backend.Dto.User
{
    public enum Gender
    {
        Male,
        Female,
        Other
    }
    public class UserRegisterDto
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required Gender Gender { get; set; }
    }
}
