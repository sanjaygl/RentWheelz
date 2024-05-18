using Microsoft.EntityFrameworkCore;
using RentWheelz.Database.Entities;

namespace RentWheelz.Database;

public class RentWheelzDbContext : DbContext
{
    public RentWheelzDbContext(DbContextOptions<RentWheelzDbContext> options) : base(options)
    {
    }

    protected RentWheelzDbContext()
    {
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Car>? Cars { get; set; }
    public DbSet<Reservation>? Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserEmail)
            .IsUnique();

        modelBuilder.Entity<Car>()
            .HasIndex(c => c.CarID)
            .IsUnique();

        modelBuilder.Entity<Car>()
            .HasIndex(c => c.RegistrationNumber)
            .IsUnique();

        modelBuilder.Entity<Reservation>()
            .HasIndex(r => r.BookingId)
            .IsUnique();
    }
}
