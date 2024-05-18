using RentWheelz.Database.Entities;
using RentWheelz.ViewModel;

namespace RentWheelz.Service.Repositories;

public interface ICarRepository
{
    Task<IEnumerable<Car>> GetAllCarsAsync();
    Task<Reservation> ReserveCarAsync(ReservationModel reservationModel);
}
