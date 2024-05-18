using FluentValidation;

namespace RentWheelz.ViewModel.Validators;
public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(login => login.UserEmail)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(login => login.UserPassword)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");
    }
}
