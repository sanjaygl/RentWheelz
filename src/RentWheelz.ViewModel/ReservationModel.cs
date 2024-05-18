namespace RentWheelz.ViewModel;

public class ReservationModel
{
    public DateTimeOffset PickupDate { get; set; }
    public DateTimeOffset ReturnDate { get; set; }
    public int NumOfTravelers { get; set; }
    public string CarId { get; set; }
}
