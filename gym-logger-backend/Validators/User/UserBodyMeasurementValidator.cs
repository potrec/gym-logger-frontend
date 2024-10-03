using FluentValidation;
using gym_logger_backend.Models.User;

namespace gym_logger_backend.Validators.User
{
    public class UserBodyMeasurementValidator : AbstractValidator<UserBodyMeasurement>
    {
        public UserBodyMeasurementValidator() 
        {
            RuleFor(x => x.Weight).NotEmpty().WithMessage("Weight is required");
            RuleFor(x => x.Height).NotEmpty().WithMessage("Height is required");
            RuleFor(x => x.BodyFatPercentage).NotEmpty().WithMessage("Body fat is required");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required");

        }
    }
}