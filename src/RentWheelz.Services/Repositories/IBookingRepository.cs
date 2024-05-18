using RentWheelz.Database.Entities;

namespace RentWheelz.Service.Repositories;

public interface IBookingRepository
{
    Task<IEnumerable<Reservation>> GetBookingsAsync(string userEmail);
    Task<bool> CancelBookingAsync(string bookingId);
}
