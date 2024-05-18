using Microsoft.EntityFrameworkCore;
using RentWheelz.Database;
using RentWheelz.Database.Entities;

namespace RentWheelz.Service.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly RentWheelzDbContext _context;

    public BookingRepository(RentWheelzDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetBookingsAsync(string userEmail)
    {
        return await _context.Reservations
            .Where(booking => booking.UserEmail == userEmail)
            .ToListAsync();
    }

    public async Task<bool> CancelBookingAsync(string bookingId)
    {
        var booking = await _context.Reservations.FindAsync(bookingId);

        if (booking == null)
        {
            return false;
        }

        _context.Reservations.Remove(booking);
        await _context.SaveChangesAsync();

        return true;
    }
}
