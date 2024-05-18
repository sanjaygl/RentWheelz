using System.ComponentModel.DataAnnotations;

namespace RentWheelz.Database.Entities;

public class Car
{
    [Key]
    [Required]
    public string CarID { get; set; } = default!;

    [Required]
    public string CarModel { get; set; } = default!;

    [Required]
    public string RegistrationNumber { get; set; } = default!;

    [Required]
    public string CarAvailability { get; set; } = default!;

    [Required]
    public string Brand { get; set; } = default!;

    [Required]
    public decimal PricePerHour { get; set; } = default!;

    [Required]
    public string Thumbnail { get; set; } = default!;
}
