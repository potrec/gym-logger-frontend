namespace gym_logger_backend.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }
}
