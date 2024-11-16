using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x=> x.Name).MinimumLength(2).WithMessage("Name must be at least 2 characters");
            RuleFor(x=> x.Name).MaximumLength(10).WithMessage("Name must be maximum 10 characters");


            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname is required");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Surname must be at least 3 characters");
            RuleFor(x => x.Surname).MaximumLength(10).WithMessage("Surname must be maximum 10 characters");

            RuleFor(x => x.City).NotEmpty().WithMessage("City is required");
            RuleFor(x => x.City).MinimumLength(2).WithMessage("City must be at least 4 characters");
            RuleFor(x => x.City).MaximumLength(15).WithMessage("City must be maximum 15 characters");




        }

    }
}
