using RentWheelz.ViewModel.Validators;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.ViewModel.UnitTests.Validators;

[ExcludeFromCodeCoverage]
[TestFixture]
public class UserModelValidatorTests
{
    private UserModelValidator _validator;

    [SetUp]
    public void Setup()
    {
        _validator = new UserModelValidator();
    }

    [Test]
    public void Validate_WhenUserNameIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = string.Empty,
            UserEmail = "user@example.com",
            UserPassword = "Password1",
            ProofId = "Proof1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.UserName)));
    }

    [Test]
    public void Validate_WhenUserNameIsNotWithinLength_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "ab", // Less than 3 characters
            UserEmail = "user@example.com",
            UserPassword = "Password1",
            ProofId = "Proof1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.UserName)));
    }

    [Test]
    public void Validate_WhenUserEmailIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "user1",
            UserEmail = string.Empty,
            UserPassword = "Password1",
            ProofId = "Proof1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.UserEmail)));
    }

    [Test]
    public void Validate_WhenUserEmailIsNotValid_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "user1",
            UserEmail = "invalid email",
            UserPassword = "Password1",
            ProofId = "Proof1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.UserEmail)));
    }

    [Test]
    public void Validate_WhenUserPasswordIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "user1",
            UserEmail = "user@example.com",
            UserPassword = string.Empty,
            ProofId = "Proof1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.UserPassword)));
    }

    [Test]
    public void Validate_WhenUserPasswordIsNotWithinLength_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "user1",
            UserEmail = "user@example.com",
            UserPassword = "123", // Less than 6 characters
            ProofId = "Proof1"
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.UserPassword)));
    }

    [Test]
    public void Validate_WhenProofIdIsEmpty_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "user1",
            UserEmail = "user@example.com",
            UserPassword = "Password1",
            ProofId = string.Empty
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.ProofId)));
    }

    [Test]
    public void Validate_WhenProofIdIsNotWithinLength_ShouldHaveValidationError()
    {
        // Arrange
        var model = new UserModel
        {
            UserName = "user1",
            UserEmail = "user@example.com",
            UserPassword = "Password1",
            ProofId = "ab" // Less than 3 characters
        };

        // Act & Assert
        var result = _validator.Validate(model);
        Assert.IsFalse(result.IsValid);
        Assert.IsTrue(result.Errors.Any(x => x.PropertyName == nameof(UserModel.ProofId)));
    }
}