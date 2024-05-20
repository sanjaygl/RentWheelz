using Moq;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.Service.UnitTests;

[ExcludeFromCodeCoverage]
[TestFixture]
public class CarServiceTests
{
    private Mock<ICarRepository> _carRepositoryMock;
    private CarService _carService;

    [SetUp]
    public void Setup()
    {
        _carRepositoryMock = new Mock<ICarRepository>();
        _carService = new CarService(_carRepositoryMock.Object);
    }

    [Test]
    public async Task GetAllCarsAsync_ReturnsAllCars()
    {
        // Arrange
        var cars = new List<Car> { new Car { CarID = "111", CarModel = "M34054" } };
        _carRepositoryMock.Setup(x => x.GetAllCarsAsync()).ReturnsAsync(cars);

        // Act
        var result = await _carService.GetAllCarsAsync();

        // Assert
        Assert.AreEqual(cars.Count, result.Count());
        Assert.AreEqual(cars[0].CarID, result.First().Id);
        Assert.AreEqual(cars[0].CarModel, result.First().Model);
    }

    [Test]
    public async Task ReserveCarAsync_ReturnsReservationResponseModel()
    {
        // Arrange
        var reservationModel = new ReservationModel { /* set properties here */ };
        var reservation = new Reservation { BookingId = "123", UserEmail = "test@example.com" };
        _carRepositoryMock.Setup(x => x.ReserveCarAsync(reservationModel)).ReturnsAsync(reservation);

        // Act
        var result = await _carService.ReserveCarAsync(reservationModel);

        // Assert
        Assert.AreEqual("success", result.Status);
        Assert.AreEqual("Reservation successful", result.Message);
        Assert.AreEqual(reservation.BookingId, result.Data.BookingId);
        Assert.AreEqual(reservation.UserEmail, result.Data.UserEmail);
    }
}
