using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;

namespace RentWheelz.Service;

public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<IEnumerable<BookingModel>> GetBookingsAsync(string userEmail)
    {
        var bookings = await _bookingRepository.GetBookingsAsync(userEmail);

        return bookings.Select(booking => new BookingModel
        {
            BookingId = booking.BookingId,
            UserEmail = booking.UserEmail,
            CarId = booking.CarID,
            ReservationDate = booking.ReservationDate.DateTime,
            PickupDate = booking.PickupDate.DateTime,
            ReturnDate = booking.ReturnDate.DateTime,
            NumOfTravellers = booking.NumOfTravelers,
            Status = booking.Status,
            Car = booking.CarName,
            Img = booking.Img,
            Total = booking.Total
        });
    }

    public async Task<bool> CancelBookingAsync(string bookingId)
    {
        return await _bookingRepository.CancelBookingAsync(bookingId);
    }
}
