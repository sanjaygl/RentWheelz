using FluentValidation.TestHelper;
using NUnit.Framework;
using RentWheelz.ViewModel.Validators;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.ViewModel.UnitTests.Validators;

[ExcludeFromCodeCoverage]
[TestFixture]
public class LoginModelValidatorTests
{
    private LoginModelValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new LoginModelValidator();
    }

    [Test]
    public void Validate_WhenUserEmailIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new LoginModel
        {
            UserEmail = string.Empty,
            UserPassword = "Password1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Email is required."));
    }

    [Test]
    public void Validate_WhenUserEmailIsNotValid_ShouldHaveValidationError()
    {
        // Arrange
        var model = new LoginModel
        {
            UserEmail = "invalid email",
            UserPassword = "Password1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Email is not valid."));
    }

    [Test]
    public void Validate_WhenUserPasswordIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new LoginModel
        {
            UserEmail = "user@example.com",
            UserPassword = string.Empty
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Password is required."));
    }

    [Test]
    public void Validate_WhenUserPasswordIsNotWithinLength_ShouldHaveValidationError()
    {
        // Arrange
        var model = new LoginModel
        {
            UserEmail = "user@example.com",
            UserPassword = "123" // Less than 6 characters
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.That(result.Errors[0].ErrorMessage, Is.EqualTo("Password must be between 6 and 100 characters."));
    }
}
