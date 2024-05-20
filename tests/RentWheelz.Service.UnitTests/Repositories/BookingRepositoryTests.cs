using Microsoft.EntityFrameworkCore;
using RentWheelz.Database;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.Service.UnitTests.Repositories;

[ExcludeFromCodeCoverage]
[TestFixture]
public class BookingRepositoryTests
{
    private RentWheelzDbContext _context;
    private BookingRepository _bookingRepository;

    [SetUp]
    public void Setup()
    {
        // Use in-memory database for testing
        var options = new DbContextOptionsBuilder<RentWheelzDbContext>()
            .UseInMemoryDatabase(databaseName: "RentWheelzTestDb")
            .Options;

        _context = new RentWheelzDbContext(options);
        _bookingRepository = new BookingRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetBookingsAsync_ReturnsAllBookingsForUser()
    {
        // Arrange
        var userEmail = "test@example.com";
        var reservation = new Reservation { BookingId = "111", UserEmail = userEmail, CarID = "1", CarName = "Car1", Img = "car1.jpg", Status = "Available" };
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        // Act
        var result = await _bookingRepository.GetBookingsAsync(userEmail);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().BookingId, Is.EqualTo("111"));
        Assert.That(result.First().UserEmail, Is.EqualTo(userEmail));
    }

    [Test]
    public async Task CancelBookingAsync_ReturnsTrueWhenCancellationIsSuccessful()
    {
        // Arrange
        var bookingId = "111";
        var reservation = new Reservation { BookingId = bookingId, UserEmail = "test@example.com", CarID = "1", CarName = "Car1", Img = "car1.jpg", Status = "Available" };
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        // Act
        var result = await _bookingRepository.CancelBookingAsync(bookingId);

        // Assert
        Assert.IsTrue(result);
    }
}
