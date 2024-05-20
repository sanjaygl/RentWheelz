using FluentValidation.TestHelper;
using NUnit.Framework;
using RentWheelz.ViewModel;
using RentWheelz.ViewModel.Validators;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.ViewModel.UnitTests.Validators;

[ExcludeFromCodeCoverage]
[TestFixture]
public class ReservationModelValidatorTests
{
    private ReservationModelValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new ReservationModelValidator();
    }

    [Test]
    public void Validate_WhenCarIdIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new ReservationModel
        {
            CarId = string.Empty,
            PickupDate = DateTimeOffset.Now,
            ReturnDate = DateTimeOffset.Now.AddDays(1),
            NumOfTravelers = 1
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(model.CarId)));
    }

    [Test]
    public void Validate_WhenPickupDateIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new ReservationModel
        {
            CarId = "123",
            PickupDate = default,
            ReturnDate = DateTimeOffset.Now.AddDays(1),
            NumOfTravelers = 1
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(model.PickupDate)));
    }

    [Test]
    public void Validate_WhenReturnDateIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new ReservationModel
        {
            CarId = "123",
            PickupDate = DateTimeOffset.Now,
            ReturnDate = default,
            NumOfTravelers = 1
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(model.ReturnDate)));
    }

    [Test]
    public void Validate_WhenNumOfTravelersIsZero_ShouldHaveValidationError()
    {
        // Arrange
        var model = new ReservationModel
        {
            CarId = "123",
            PickupDate = DateTimeOffset.Now,
            ReturnDate = DateTimeOffset.Now.AddDays(1),
            NumOfTravelers = 0
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(model.NumOfTravelers)));
    }
}
