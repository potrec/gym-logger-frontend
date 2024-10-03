using gym_logger_backend.Dto.User;
using System.Diagnostics.CodeAnalysis;
using static gym_logger_backend.Dto.User.UserProfileDto;
using UserProfileDto = gym_logger_backend.Dto.User.UserProfileDto;
namespace gym_logger_backend.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string PasswordHash { get; set; }
        public UserDetails UserDetails { get; set; } = new UserDetails();
        public ICollection<UserBodyMeasurement> UserBodyMeasurements { get; set; } = new List<UserBodyMeasurement>();

        [SetsRequiredMembers]
        public User()
        {
        }

        public static User FromUserDto(UserProfileDto userDto)
        {
            return new User
            {
                Email = userDto.Email,
                UserName = userDto.UserName,
                PasswordHash = userDto.PasswordHash,
                UserDetails = new UserDetails
                {
                    FirstName = userDto.UserDetails.FirstName,
                    LastName = userDto.UserDetails.LastName,
                    DateOfBirth = userDto.UserDetails.DateOfBirth,
                },
            };
        }
    }
}
