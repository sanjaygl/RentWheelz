using Moq;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.Service.UnitTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class UserServiceTests
{
    private Mock<IUserRepository> _userRepositoryMock;
    private UserService _userService;

    [SetUp]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_userRepositoryMock.Object);
    }

    [Test]
    public async Task RegisterUserAsync_ExistingUser_ReturnsFalse()
    {
        // Arrange
        var userModel = new UserModel
        {
            UserName = "testuser",
            UserEmail = "testuser@example.com",
            UserPassword = "password",
            ProofId = "123456"
        };

        var existingUser = new User
        {
            UserName = "testuser",
            UserEmail = "testuser@example.com",
            UserPassword = "password",
            ProofId = "123456"
        };

        _userRepositoryMock.Setup(x => x.GetUserAsync(userModel.UserName, userModel.UserEmail))
            .ReturnsAsync(existingUser);

        // Act
        var result = await _userService.RegisterUserAsync(userModel);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public async Task RegisterUserAsync_NewUser_ReturnsTrue()
    {
        // Arrange
        var userModel = new UserModel
        {
            UserName = "testuser",
            UserEmail = "testuser@example.com",
            UserPassword = "password",
            ProofId = "123456"
        };

        _userRepositoryMock.Setup(x => x.GetUserAsync(userModel.UserName, userModel.UserEmail))
            .ReturnsAsync((User)null);

        // Act
        var result = await _userService.RegisterUserAsync(userModel);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public async Task LoginAsync_ValidCredentials_ReturnsLoginResponseModel()
    {
        // Arrange
        var loginModel = new LoginModel
        {
            UserEmail = "testuser@example.com",
            UserPassword = "password"
        };

        var user = new User
        {
            UserName = "testuser",
            UserEmail = "testuser@example.com",
            UserPassword = "password",
            ProofId = "123456"
        };

        _userRepositoryMock.Setup(x => x.GetUserByEmailAsync(loginModel.UserEmail))
            .ReturnsAsync(user);

        // Act
        var result = await _userService.LoginAsync(loginModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual("success", result.Status);
        Assert.AreEqual("Login successful", result.Message);
        Assert.IsNotNull(result.Data);
        Assert.AreEqual(user.UserName, result.Data.UserName);
        Assert.AreEqual(user.UserEmail, result.Data.UserEmail);
        Assert.AreEqual(user.ProofId, result.Data.ProofId);
    }

    [Test]
    public async Task LoginAsync_InvalidCredentials_ReturnsNull()
    {
        // Arrange
        var loginModel = new LoginModel
        {
            UserEmail = "testuser@example.com",
            UserPassword = "wrongpassword"
        };

        var user = new User
        {
            UserName = "testuser",
            UserEmail = "testuser@example.com",
            UserPassword = "password",
            ProofId = "123456"
        };

        _userRepositoryMock.Setup(x => x.GetUserByEmailAsync(loginModel.UserEmail))
            .ReturnsAsync(user);

        // Act
        var result = await _userService.LoginAsync(loginModel);

        // Assert
        Assert.IsNull(result);
    }
}
