using System.ComponentModel.DataAnnotations;

namespace RentWheelz.Database.Entities;

public class User
{
    [Key]
    [Required]
    [StringLength(50)]
    public string UserName { get; set; } = default!;

    [Required]
    [EmailAddress]
    public string UserEmail { get; set; } = default!;

    [Required]
    public string UserPassword { get; set; } = default!;

    [Required]
    public string ProofId { get; set; } = default!;
}
