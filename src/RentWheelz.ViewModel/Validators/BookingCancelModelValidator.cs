using FluentValidation;

namespace RentWheelz.ViewModel.Validators;

public class BookingCancelModelValidator : AbstractValidator<BookingCancelModel>
{
    public BookingCancelModelValidator()
    {
        RuleFor(x => x.BookingId).NotEmpty();
    }
}
