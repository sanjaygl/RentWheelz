using Moq;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;

namespace RentWheelz.Service.UnitTests;

[TestFixture]
public class BookingServiceTests
{
    private Mock<IBookingRepository> _bookingRepositoryMock;
    private BookingService _bookingService;

    [SetUp]
    public void Setup()
    {
        _bookingRepositoryMock = new Mock<IBookingRepository>();
        _bookingService = new BookingService(_bookingRepositoryMock.Object);
    }

    [Test]
    public async Task GetBookingsAsync_ReturnsAllBookingsForUser()
    {
        // Arrange
        var userEmail = "test@example.com";
        var bookings = new List<Reservation> { new Reservation { BookingId = "111", UserEmail = userEmail } };
        _bookingRepositoryMock.Setup(x => x.GetBookingsAsync(userEmail)).ReturnsAsync(bookings);

        // Act
        var result = await _bookingService.GetBookingsAsync(userEmail);

        // Assert
        Assert.AreEqual(bookings.Count, result.Count());
        Assert.AreEqual(bookings[0].BookingId, result.First().BookingId);
        Assert.AreEqual(bookings[0].UserEmail, result.First().UserEmail);
    }

    [Test]
    public async Task CancelBookingAsync_ReturnsTrueWhenCancellationIsSuccessful()
    {
        // Arrange
        var bookingId = "111";
        _bookingRepositoryMock.Setup(x => x.CancelBookingAsync(bookingId)).ReturnsAsync(true);

        // Act
        var result = await _bookingService.CancelBookingAsync(bookingId);

        // Assert
        Assert.IsTrue(result);
    }
}
