namespace gym_logger_backend.Models.User
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public int Gender { get; set; } = 0;
        public int Status { get; set; } = 0;
    }
}
