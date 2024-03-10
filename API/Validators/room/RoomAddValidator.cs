using API.Dtos.Room;
using FluentValidation;

namespace API.Validators.room
{
    public class RoomAddValidator : AbstractValidator<RoomAddRequest>
    {
        public RoomAddValidator()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("Name is required")
                .Length(10, 100).WithMessage("Name must be between 10 and 100 characters");
            RuleFor(x => x.description).NotEmpty().WithMessage("Description is required")
                .Length(10, 1000).WithMessage("Description must be between 10 and 1000 characters");
            RuleFor(x => x.price)
                .GreaterThan(0).WithMessage("Price must be greater than 0")
                .LessThan(1000000000).WithMessage("Price must be less than 1000000000");
            RuleFor(x => x.area)
                .GreaterThan(0).WithMessage("Area must be greater than 0")
                .LessThan(1000000000).WithMessage("Area must be less than 1000000000");
            RuleFor(x => x.phone).NotEmpty().WithMessage("Phone is required")
                .Matches(@"^0[0-9]{9}$").WithMessage("Phone is invalid");
            RuleFor(x => x.email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is invalid");
            RuleFor(x => x.latitude).NotEmpty().WithMessage("Latitude is required");
            RuleFor(x => x.longitude).NotEmpty().WithMessage("Longitude is required");


        }
    }
}
