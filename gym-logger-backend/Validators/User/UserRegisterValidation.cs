using FluentValidation;
using gym_logger_backend.Dto.User;
using gym_logger_backend.Repository;

namespace gym_logger_backend.Validators.User
{
    public class UserRegisterValidation : AbstractValidator<UserRegisterDto>
    {
        private readonly IUserRepository _userRepository;
        public UserRegisterValidation() {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.UserName).MustAsync(async (userName, _) =>
            {
                return await _userRepository.IsUserNameUniqueAsync(userName) == null;
            }).WithMessage("Account with this username already exists");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password must be at least 8 characters");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Passwords do not match");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth is required");
        }
    }
}
