using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RentWheelz.Database;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RentWheelz.Service.UnitTests.Repositories;

[TestFixture]
public class CarRepositoryTests
{
    private RentWheelzDbContext _context;
    private CarRepository _carRepository;

    [SetUp]
    public void Setup()
    {
        // Use in-memory database for testing
        var options = new DbContextOptionsBuilder<RentWheelzDbContext>()
            .UseInMemoryDatabase(databaseName: "RentWheelzTestDb")
            .Options;

        _context = new RentWheelzDbContext(options);
        _carRepository = new CarRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetAllCarsAsync_ReturnsAllCars()
    {
        // Arrange
        _context.Cars.Add(new Car { CarID = "111", CarModel = "Model1" });
        await _context.SaveChangesAsync();

        // Act
        var result = await _carRepository.GetAllCarsAsync();

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.That(result.First().CarID, Is.EqualTo("111"));
        Assert.That(result.First().CarModel, Is.EqualTo("Model1"));
    }

    [Test]
    public async Task ReserveCarAsync_ReturnsReservationWhenCarIsAvailable()
    {
        // Arrange
        var carId = "111";
        _context.Cars.Add(new Car { CarID = carId, CarModel = "Model1", CarAvailability = "AVAILABLE" });
        await _context.SaveChangesAsync();

        var reservationModel = new ReservationModel
        {
            CarId = carId,
            PickupDate = DateTimeOffset.Now,
            ReturnDate = DateTimeOffset.Now.AddDays(1),
            NumOfTravelers = 1
        };

        // Act
        var result = await _carRepository.ReserveCarAsync(reservationModel);

        // Assert
        Assert.IsNotNull(result);
        Assert.That(result.CarID, Is.EqualTo(carId));
    }
}
