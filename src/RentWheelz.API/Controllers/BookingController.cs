using Microsoft.AspNetCore.Mvc;
using RentWheelz.Service;
using RentWheelz.ViewModel;

namespace RentWheelz.API.Controllers;

[ApiController]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost("my-bookings")]
    public async Task<IActionResult> MyBookings([FromBody] MyBookingModel myBookingModel)
    {
        var bookings = await _bookingService.GetBookingsAsync(myBookingModel.UserEmail);

        return Ok(new
        {
            status = "success",
            data = new { bookings }
        });
    }

    [HttpPost("cancel")]
    public async Task<IActionResult> Cancel([FromBody] BookingCancelModel cancelModel)
    {
        var result = await _bookingService.CancelBookingAsync(cancelModel.BookingId);

        if (!result)
        {
            return BadRequest(new { status = "error", message = "Unable to cancel booking" });
        }

        return Ok(new { status = "success", message = "Your reservation is canceled" });
    }
}
