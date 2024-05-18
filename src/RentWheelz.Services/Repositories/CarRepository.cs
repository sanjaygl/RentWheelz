using Microsoft.EntityFrameworkCore;
using RentWheelz.Database;
using RentWheelz.Database.Entities;
using RentWheelz.ViewModel;

namespace RentWheelz.Service.Repositories;

public class CarRepository : ICarRepository
{
    private readonly RentWheelzDbContext _context;

    public CarRepository(RentWheelzDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Car>> GetAllCarsAsync()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<Reservation> ReserveCarAsync(ReservationModel reservationModel)
    {
        var car = await _context.Cars.FindAsync(reservationModel.CarId);

        if (car is null || car.CarAvailability != "AVAILABLE")
        {
            return null;
        }

        var loogedInUseruserEmail = "krishna@abc.com";
        var user = await _context.Users.FirstOrDefaultAsync(x => x.UserEmail == loogedInUseruserEmail);

        if (user == null)
        {
            throw new Exception("User not found.");
        }

        var reservation = new Reservation
        {
            BookingId = GenerateBookingId(),
            CarID = car.CarID,
            PickupDate = reservationModel.PickupDate.ToUniversalTime(),
            ReturnDate = reservationModel.ReturnDate.ToUniversalTime(),
            NumOfTravelers = reservationModel.NumOfTravelers,
            CarName = car.CarModel,
            Status = "PENDING",
            ReservationDate = DateTimeOffset.UtcNow,
            Total = car.PricePerHour * Convert.ToDecimal((reservationModel.ReturnDate - reservationModel.PickupDate).TotalHours),
            Img = car.Thumbnail,
            UserEmail = loogedInUseruserEmail,
        };

        _context.Entry(reservation).State = EntityState.Added; // Set the state of the reservation entity to Added
        await _context.SaveChangesAsync();

        return reservation;
    }

    private string GenerateBookingId()
    {
        // Generate a unique booking ID using a combination of current timestamp and a random number
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        string random = new Random().Next(1000, 9999).ToString();

        return $"B{timestamp}{random}";
    }
}
