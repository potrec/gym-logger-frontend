using FluentValidation;
using gym_logger_backend.Dto.User;

namespace gym_logger_backend.Validators.User
{
    public class UserProfileValidator : AbstractValidator<UserProfileDto>
    {
        public UserProfileValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required");
            RuleFor(x => x.UserName).MinimumLength(6).WithMessage("Username must be at least 6 characters");
            RuleFor(x => x.UserDetails.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(x => x.UserDetails.FirstName).MinimumLength(2).WithMessage("First name must be at least 2 characters");
            RuleFor(x => x.UserDetails.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(x => x.UserDetails.LastName).MinimumLength(2).WithMessage("Last name must be at least 2 characters");
            RuleFor(x => x.UserDetails.DateOfBirth).NotEmpty().WithMessage("Date of birth is required");
        }
    }
}