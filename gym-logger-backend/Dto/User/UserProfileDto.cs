using UserModel = gym_logger_backend.Models.User.User;

namespace gym_logger_backend.Dto.User
{
    public class UserProfileDto
    {
        public int Id { get; } 
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public UserDetailsDto UserDetails { get; set; }
        public List<UserBodyMeasurementDto> UserBodyMeasurements { get; set; }

        public static UserProfileDto FromUser(UserModel user)
        {
            return new UserProfileDto
            {
                Email = user.Email,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                UserDetails = new UserDetailsDto
                {
                    Id = user.UserDetails.Id,
                    FirstName = user.UserDetails.FirstName,
                    LastName = user.UserDetails.LastName,
                    DateOfBirth = user.UserDetails.DateOfBirth,
                    Gender = user.UserDetails.Gender,
                    Status = user.UserDetails.Status
                },
                UserBodyMeasurements = user.UserBodyMeasurements.Select(ubm => new UserBodyMeasurementDto
                {
                }).ToList()
            };
        }

        public class UserDetailsDto
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public int Gender { get; set; }
            public int Status { get; set; }
        }

        public class UserBodyMeasurementDto
        {

        }
    }
}
