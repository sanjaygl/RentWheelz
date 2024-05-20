using FluentValidation.TestHelper;
using NUnit.Framework;
using RentWheelz.ViewModel;
using RentWheelz.ViewModel.Validators;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.ViewModel.UnitTests.Validators;

[ExcludeFromCodeCoverage]
[TestFixture]
public class BookingCancelModelValidatorTests
{
    private BookingCancelModelValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new BookingCancelModelValidator();
    }

    [Test]
    public void Validate_WhenBookingIdIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new BookingCancelModel
        {
            BookingId = string.Empty
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(model.BookingId)));
    }

    [Test]
    public void Validate_WhenBookingIdIsNotEmpty_ShouldNotHaveValidationError()
    {
        // Arrange
        var model = new BookingCancelModel
        {
            BookingId = "123"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsTrue(result.IsValid);
        Assert.IsFalse(result.Errors.Any(x => x.PropertyName == nameof(model.BookingId)));
    }
}
