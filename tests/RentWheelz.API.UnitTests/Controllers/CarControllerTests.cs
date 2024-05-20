using Moq;
using RentWheelz.API.Controllers;
using RentWheelz.Service;
using RentWheelz.ViewModel;
using Microsoft.AspNetCore.Mvc;
using RentWheelz.Database.Entities;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.API.UnitTests.Controllers;

[ExcludeFromCodeCoverage]
[TestFixture]
public class CarControllerTests
{
    private Mock<ICarService> _carServiceMock;
    private CarController _carController;

    [SetUp]
    public void Setup()
    {
        _carServiceMock = new Mock<ICarService>();
        _carController = new CarController(_carServiceMock.Object);
    }

    [Test]
    public async Task GetPackages_ReturnsOk()
    {
        // Arrange
        var cars = new List<CarModel> { new CarModel() { Id = "111", Model = "M34054" } };
        _carServiceMock.Setup(x => x.GetAllCarsAsync()).ReturnsAsync(cars);

        // Act
        var result = await _carController.GetPackages();

        // Assert
        Assert.IsInstanceOf<OkObjectResult>(result);
        var okResult = result as OkObjectResult;
        Assert.NotNull(okResult);

        var data = okResult.Value as dynamic;
        Assert.NotNull(data);
    }

    [Test]
    public async Task Reserve_UnableToReserve_ReturnsBadRequest()
    {
        var reservationModel = new ReservationModel { /* set properties here */ };
        _carServiceMock.Setup(x => x.ReserveCarAsync(reservationModel)).ReturnsAsync((ReservationResponseModel?)null);

        var result = await _carController.Reserve(reservationModel);

        Assert.IsInstanceOf<BadRequestObjectResult>(result);
    }

    [Test]
    public async Task Reserve_SuccessfulReservation_ReturnsOk()
    {
        var reservationModel = new ReservationModel { /* set properties here */ };
        var reservationResponseModel = new ReservationResponseModel { /* set properties here */ };
        _carServiceMock.Setup(x => x.ReserveCarAsync(reservationModel)).ReturnsAsync(reservationResponseModel);

        var result = await _carController.Reserve(reservationModel);

        Assert.IsInstanceOf<OkObjectResult>(result);
    }
}
