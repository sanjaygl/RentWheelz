using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RentWheelz.Database.Entities;

public class Reservation
{
    [Key]
    [Required]
    public string BookingId { get; set; } = default!;

    [Required]
    public string UserEmail { get; set; } = default!;

    [Required]
    public string CarID { get; set; } = default!;

    [Required]
    public DateTimeOffset ReservationDate { get; set; }

    [Required]
    public DateTimeOffset PickupDate { get; set; }

    [Required]
    public DateTimeOffset ReturnDate { get; set; }

    [Required]
    public int NumOfTravelers { get; set; } = default!;

    [Required]
    public string Status { get; set; } = default!;

    [Required]
    public string CarName { get; set; } = default!;

    [Required]
    public string Img { get; set; } = default!;

    [Required]
    public decimal Total { get; set; } = default!;
}
