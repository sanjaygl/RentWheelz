using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using RentWheelz.Database;
using RentWheelz.Database.Entities;
using RentWheelz.Service.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace RentWheelz.Service.UnitTests.Repositories;

[TestFixture]
public class UserRepositoryTests
{
    private RentWheelzDbContext _context;
    private UserRepository _userRepository;

    [SetUp]
    public void Setup()
    {
        // Use in-memory database for testing
        var options = new DbContextOptionsBuilder<RentWheelzDbContext>()
            .UseInMemoryDatabase(databaseName: "RentWheelzTestDb")
            .Options;

        _context = new RentWheelzDbContext(options);
        _userRepository = new UserRepository(_context);
    }

    [TearDown]
    public void TearDown()
    {
        _context.Dispose();
    }

    [Test]
    public async Task GetUserAsync_ReturnsUserWithMatchingUserNameOrEmail()
    {
        // Arrange
        var userName = "testUser";
        var userEmail = "test@example.com";
        _context.Users.Add(new User { UserName = userName, UserEmail = userEmail });
        await _context.SaveChangesAsync();

        // Act
        var result = await _userRepository.GetUserAsync(userName, userEmail);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserName, Is.EqualTo(userName));
        Assert.That(result.UserEmail, Is.EqualTo(userEmail));
    }

    [Test]
    public async Task GetUserByEmailAsync_ReturnsUserWithMatchingEmail()
    {
        // Arrange
        var userEmail = "test@example.com";
        _context.Users.Add(new User { UserName = "testUser", UserEmail = userEmail });
        await _context.SaveChangesAsync();

        // Act
        var result = await _userRepository.GetUserByEmailAsync(userEmail);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.UserEmail, Is.EqualTo(userEmail));
    }
}
