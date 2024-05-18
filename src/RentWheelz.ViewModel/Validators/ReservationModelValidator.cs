using FluentValidation;

namespace RentWheelz.ViewModel.Validators;

public class ReservationModelValidator : AbstractValidator<ReservationModel>
{
    public ReservationModelValidator()
    {
        RuleFor(x => x.CarId).NotEmpty();
        RuleFor(x => x.PickupDate).NotEmpty();
        RuleFor(x => x.ReturnDate).NotEmpty();
        RuleFor(x => x.NumOfTravelers).GreaterThan(0);
    }
}
