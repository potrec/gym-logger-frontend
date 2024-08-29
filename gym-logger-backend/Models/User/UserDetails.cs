namespace gym_logger_backend.Models.User
{
    public class UserDetails
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Gender { get; set; } = String.Empty;
        public int Status { get; set; } = 0;
    }
}
