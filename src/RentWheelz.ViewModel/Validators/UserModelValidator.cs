using FluentValidation;

namespace RentWheelz.ViewModel.Validators;

public class UserModelValidator : AbstractValidator<UserModel>
{
    public UserModelValidator()
    {
        RuleFor(user => user.UserName)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");

        RuleFor(user => user.UserEmail)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(user => user.UserPassword)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 100).WithMessage("Password must be between 6 and 100 characters.");

        RuleFor(user => user.ProofId)
            .NotEmpty().WithMessage("Proof ID is required.")
            .Length(3, 50).WithMessage("Proof ID must be between 3 and 50 characters.");
    }
}
