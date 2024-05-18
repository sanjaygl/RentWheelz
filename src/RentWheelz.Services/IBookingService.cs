using RentWheelz.ViewModel;

namespace RentWheelz.Service;

public interface IBookingService
{
    Task<IEnumerable<BookingModel>> GetBookingsAsync(string userEmail);
    Task<bool> CancelBookingAsync(string bookingId);
}
