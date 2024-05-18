using FluentValidation;

namespace RentWheelz.ViewModel.Validators;

public class MyBookingModelValidator : AbstractValidator<MyBookingModel>
{
    public MyBookingModelValidator()
    {
        RuleFor(x => x.UserEmail).NotEmpty().EmailAddress();
    }
}
