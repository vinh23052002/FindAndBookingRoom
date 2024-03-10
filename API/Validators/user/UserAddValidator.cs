using API.Dtos.User;
using FluentValidation;

namespace API.Validators.user
{
    public class UserAddValidator : AbstractValidator<UserRequest>
    {
        public UserAddValidator()
        {
            RuleFor(x => x.userID).NotEmpty();
            RuleFor(x => x.password).NotEmpty().Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$").WithMessage("Password must be at least 8 characters, at least one uppercase letter, one lowercase letter and one number.");
            RuleFor(x => x.fullName).NotEmpty();
            RuleFor(x => x.email).NotEmpty().EmailAddress();
            RuleFor(x => x.phone).NotEmpty().Matches(@"^\d{9,10}$").WithMessage("Phone number must be 9 or 10 digits.");
            RuleFor(x => x.roleID).NotEmpty();
            RuleFor(x => x.wardID).NotEmpty();
        }
    }
}
