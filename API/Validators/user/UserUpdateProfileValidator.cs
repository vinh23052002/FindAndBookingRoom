using API.Dtos.User;
using FluentValidation;

namespace API.Validators.user
{
    public class UserUpdateProfileValidator : AbstractValidator<UserUpdateProfileRequest>
    {
        public UserUpdateProfileValidator()
        {
            RuleFor(x => x.userID).NotEmpty();
            RuleFor(x => x.fullName).NotEmpty();
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.phone).NotEmpty().Matches(@"^\d{9,10}$").WithMessage("Phone number must be 9 or 10 digits.");
            RuleFor(x => x.wardID).NotEmpty();
        }
    }
}
