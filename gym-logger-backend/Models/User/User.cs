using System.Diagnostics.CodeAnalysis;

namespace gym_logger_backend.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public UserDetails UserDetails { get; set; } = new UserDetails();
        public ICollection<UserBodyMeasurements> UserBodyMeasurements { get; set; } = new List<UserBodyMeasurements>();

        [SetsRequiredMembers]
        public User()
        {
        }
    }
}
