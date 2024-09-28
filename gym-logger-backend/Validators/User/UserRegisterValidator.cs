using FluentValidation;
using gym_logger_backend.Dto.User;
using gym_logger_backend.Repository;

namespace gym_logger_backend.Validators.User
{
    public class UserRegisterValidator : AbstractValidator<UserRegisterDto>
    {
        private readonly IUserRepository _userRepository;

        public UserRegisterValidator(IUserRepository _userRepository) {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required").MustAsync(async (userName, _) =>
            {
                return await _userRepository.IsUserNameUniqueAsync(userName) == null;
            }).WithMessage("Account with this username already exists");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Email is not valid").MustAsync(async (email, _) =>
            {
                return await _userRepository.IsEmailUniqueAsync(email) == null;
            }).WithMessage("Account with this email already exists");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6).WithMessage("Password must be at least 8 characters").Equal(x => x.ConfirmPassword).WithMessage("Passwords do not match");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("Date of birth is required")
            .Must(BeValidDateFormat)
            .WithMessage("Invalid date format. Please use dd-MM-yyyy");
            RuleFor(x => x.Gender).InclusiveBetween(0, 2);
        }
        private bool BeValidDateFormat(string dateString)
        {
            string[] formats = { "dd-MM-yyyy" };
            return DateTime.TryParseExact(dateString, formats, null, System.Globalization.DateTimeStyles.None, out _);
        }
    }
}
