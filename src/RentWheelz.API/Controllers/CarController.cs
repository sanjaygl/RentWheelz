using Microsoft.AspNetCore.Mvc;
using RentWheelz.Service;
using RentWheelz.ViewModel;

namespace RentWheelz.API.Controllers;

[ApiController]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet("getPackages")]
    public async Task<IActionResult> GetPackages()
    {
        var cars = await _carService.GetAllCarsAsync();

        return Ok(new
        {
            status = "success",
            results = cars.Count(),
            data = new { cars }
        });
    }

    [HttpPost("reserve")]
    public async Task<IActionResult> Reserve([FromBody] ReservationModel reservationModel)
    {
        var result = await _carService.ReserveCarAsync(reservationModel);

        if (result == null)
        {
            return BadRequest(new { status = "error", message = "Unable to reserve car" });
        }

        return Ok(result);
    }
}