using RentWheelz.ViewModel;

namespace RentWheelz.Service;
public interface ICarService
{
    Task<IEnumerable<CarModel>> GetAllCarsAsync();
    Task<ReservationResponseModel> ReserveCarAsync(ReservationModel reservationModel);
}
