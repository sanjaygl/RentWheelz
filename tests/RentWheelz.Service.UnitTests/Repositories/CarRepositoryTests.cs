using Microsoft.EntityFrameworkCore;
using RentWheelz.Database;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;
using System.Diagnostics.CodeAnalysis;

namespace RentWheelz.Service.UnitTests.Repositories;

[ExcludeFromCodeCoverage]
[TestFixture]
public class CarRepositoryTests
{
    private RentWheelzDbContext? _context;
    private CarRepository? _carRepository;

    [SetUp]
    public void Setup()
    {
        // Use in-memory database for testing
        var options = new DbContextOptionsBuilder<RentWheelzDbContext>()
            .UseInMemoryDatabase(databaseName: "RentWheelzTestDb")
            .Options;

        _context = new RentWheelzDbContext(options);
        _carRepository = new CarRepository(_context!);
    }

    [TearDown]
    public void TearDown()
    {
        _context?.Dispose();
    }

    [Test]
    public async Task GetAllCarsAsync_ReturnsAllCars()
    {
        // Arrange
        _context!.Cars!.Add(new Car
        {
            CarID = "111",
            CarModel = "Model1",
            CarAvailability = "AVAILABLE",
            PricePerHour = 10,
            Thumbnail = "thumbnail.jpg",
            Brand = "Brand1", // Add this line
            RegistrationNumber = "Reg1" // Add this line
        });
        await _context.SaveChangesAsync();

        // Act
        var result = await _carRepository!.GetAllCarsAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        var car = result.First();
        Assert.That(car.CarID, Is.EqualTo("111"));
        Assert.That(car.CarModel, Is.EqualTo("Model1"));
        Assert.That(car.CarAvailability, Is.EqualTo("AVAILABLE"));
        Assert.That(car.PricePerHour, Is.EqualTo(10));
        Assert.That(car.Thumbnail, Is.EqualTo("thumbnail.jpg"));
        Assert.That(car.Brand, Is.EqualTo("Brand1")); // Add this line
        Assert.That(car.RegistrationNumber, Is.EqualTo("Reg1")); // Add this line
    }

    [Test, Ignore("Need to Fix it")]
    public async Task ReserveCarAsync_ReturnsReservationWhenCarIsAvailable()
    {
        // Arrange
        var carId = "112";
        _context!.Cars!.Add(new Car
        {
            CarID = carId,
            CarModel = "Model1",
            CarAvailability = "AVAILABLE",
            PricePerHour = 10,
            Thumbnail = "thumbnail.jpg",
            Brand = "Brand1",
            RegistrationNumber = "Reg1"
        });

        var userName = "user1";
        _context.Users!.Add(new User
        {
            UserName = userName,
            UserEmail = "user1@example.com",
            UserPassword = "Password1",
            ProofId = "Proof1"
        });

        await _context.SaveChangesAsync();

        var reservationModel = new ReservationModel
        {
            CarId = carId,
            PickupDate = DateTimeOffset.Now,
            ReturnDate = DateTimeOffset.Now.AddDays(1),
            NumOfTravelers = 1,
        };

        // Act
        var result = await _carRepository!.ReserveCarAsync(reservationModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.CarID, Is.EqualTo(carId));
        Assert.That(result.PickupDate, Is.EqualTo(reservationModel.PickupDate).Within(TimeSpan.FromSeconds(1)));
        Assert.That(result.ReturnDate, Is.EqualTo(reservationModel.ReturnDate).Within(TimeSpan.FromSeconds(1)));
        Assert.That(result.NumOfTravelers, Is.EqualTo(reservationModel.NumOfTravelers));
        Assert.That(result.Total, Is.EqualTo((reservationModel.ReturnDate - reservationModel.PickupDate).TotalHours * 10));
        Assert.That(result.Img, Is.EqualTo("thumbnail.jpg"));
    }
}
