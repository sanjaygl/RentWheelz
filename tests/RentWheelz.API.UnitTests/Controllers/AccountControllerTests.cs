using Moq;
using RentWheelz.API.Controllers;
using RentWheelz.Service;
using RentWheelz.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace RentWheelz.API.UnitTests;

[TestFixture]
public class AccountControllerTests
{
    private Mock<IUserService> _userServiceMock;
    private AccountController _accountController;

    [SetUp]
    public void Setup()
    {
        _userServiceMock = new Mock<IUserService>();
        _accountController = new AccountController(_userServiceMock.Object);
    }

    [Test]
    public async Task Register_UserAlreadyExists_ReturnsBadRequest()
    {
        var userModel = new UserModel { /* set properties here */ };
        _userServiceMock.Setup(x => x.RegisterUserAsync(userModel)).ReturnsAsync(false);

        var result = await _accountController.Register(userModel);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Register_UserDoesNotExist_ReturnsOk()
    {
        var userModel = new UserModel { /* set properties here */ };
        _userServiceMock.Setup(x => x.RegisterUserAsync(userModel)).ReturnsAsync(true);

        var result = await _accountController.Register(userModel);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task Login_InvalidCredentials_ReturnsBadRequest()
    {
        var loginModel = new LoginModel { /* set properties here */ };
        _userServiceMock.Setup(x => x.LoginAsync(loginModel)).ReturnsAsync((LoginResponseModel)null);

        var result = await _accountController.Login(loginModel);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Login_ValidCredentials_ReturnsOk()
    {
        var loginModel = new LoginModel { /* set properties here */ };
        var loginResponseModel = new LoginResponseModel { /* set properties here */ };
        _userServiceMock.Setup(x => x.LoginAsync(loginModel)).ReturnsAsync(loginResponseModel);

        var result = await _accountController.Login(loginModel);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}
