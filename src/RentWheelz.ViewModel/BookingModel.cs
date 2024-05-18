namespace RentWheelz.ViewModel;

public class BookingModel
{
    public string BookingId { get; set; }
    public string UserEmail { get; set; }
    public string CarId { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime PickupDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int NumOfTravellers { get; set; }
    public string Status { get; set; }
    public string Car { get; set; }
    public string Img { get; set; }
    public decimal Total { get; set; }
}
