using RentWheelz.Service.Repositories;
using RentWheelz.ViewModel;

namespace RentWheelz.Service;
public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<IEnumerable<CarModel>> GetAllCarsAsync()
    {
        var cars = await _carRepository.GetAllCarsAsync();

        return cars.Select(car => new CarModel
        {
            Id = car.CarID,
            Model = car.CarModel,
            Brand = car.Brand,
            RegistrationNumber = car.RegistrationNumber,
            PricePerHour = car.PricePerHour,
            Status = car.CarAvailability,
            Thumbnail = car.Thumbnail
        });
    }

    public async Task<ReservationResponseModel> ReserveCarAsync(ReservationModel reservationModel)
    {
        var reservation = await _carRepository.ReserveCarAsync(reservationModel);

        if (reservation == null)
        {
            return null;
        }

        return new ReservationResponseModel
        {
            Status = "success",
            Message = "Reservation successful",
            Data = new ReservationData
            {
                BookingId = reservation.BookingId,
                UserEmail = reservation.UserEmail
            }
        };
    }
}
