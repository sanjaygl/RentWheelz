using Microsoft.AspNetCore.Mvc;
using RentWheelz.Service;
using RentWheelz.ViewModel;

namespace RentWheelz.API.Controllers;

[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] UserModel user)
    {
        var result = await _userService.RegisterUserAsync(user);

        if (!result)
        {
            return BadRequest(new { status = "error", message = "User already exists" });
        }

        return Ok(new { status = "success", message = "User registered successfully" });
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var result = await _userService.LoginAsync(loginModel);

        if (result == null)
        {
            return BadRequest(new { status = "error", message = "Invalid email or password" });
        }

        return Ok(result);
    }
}