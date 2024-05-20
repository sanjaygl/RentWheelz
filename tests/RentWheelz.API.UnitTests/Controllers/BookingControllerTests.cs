using Moq;
using RentWheelz.API.Controllers;
using RentWheelz.Service;
using RentWheelz.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.API.UnitTests.Controllers;

[ExcludeFromCodeCoverage]
[TestFixture]
public class BookingControllerTests
{
    private Mock<IBookingService> _bookingServiceMock;
    private BookingController _bookingController;

    [SetUp]
    public void Setup()
    {
        _bookingServiceMock = new Mock<IBookingService>();
        _bookingController = new BookingController(_bookingServiceMock.Object);
    }

    [Test]
    public async Task MyBookings_ReturnsOk()
    {
        var myBookingModel = new MyBookingModel { UserEmail = "test@example.com" };
        var bookings = new List<BookingModel> { /* populate with test data */ };
        _bookingServiceMock.Setup(x => x.GetBookingsAsync(myBookingModel.UserEmail)).ReturnsAsync(bookings);

        var result = await _bookingController.MyBookings(myBookingModel);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }

    [Test]
    public async Task Cancel_UnableToCancel_ReturnsBadRequest()
    {
        var cancelModel = new BookingCancelModel { BookingId = "123" };
        _bookingServiceMock.Setup(x => x.CancelBookingAsync(cancelModel.BookingId)).ReturnsAsync(false);

        var result = await _bookingController.Cancel(cancelModel);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Cancel_SuccessfulCancellation_ReturnsOk()
    {
        var cancelModel = new BookingCancelModel { BookingId = "123" };
        _bookingServiceMock.Setup(x => x.CancelBookingAsync(cancelModel.BookingId)).ReturnsAsync(true);

        var result = await _bookingController.Cancel(cancelModel);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}

