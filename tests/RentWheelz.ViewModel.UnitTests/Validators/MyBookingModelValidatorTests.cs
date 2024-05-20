using FluentValidation.TestHelper;
using NUnit.Framework;
using RentWheelz.ViewModel;
using RentWheelz.ViewModel.Validators;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.ViewModel.UnitTests.Validators;

[ExcludeFromCodeCoverage]
[TestFixture]
public class MyBookingModelValidatorTests
{
    private MyBookingModelValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new MyBookingModelValidator();
    }

    [Test]
    public void Validate_WhenUserEmailIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new MyBookingModel
        {
            UserEmail = string.Empty
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(e => e.PropertyName == nameof(model.UserEmail)));
    }

    [Test]
    public void Validate_WhenUserEmailIsNotValid_ShouldHaveValidationError()
    {
        // Arrange
        var model = new MyBookingModel
        {
            UserEmail = "invalid email"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(e => e.PropertyName == nameof(model.UserEmail)));
    }

    [Test]
    public void Validate_WhenUserEmailIsValid_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new MyBookingModel
        {
            UserEmail = "user@example.com"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsTrue(result.IsValid);
        Assert.IsFalse(result.Errors.Any(e => e.PropertyName == nameof(model.UserEmail)));
    }
}
