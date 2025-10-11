namespace FuelTracker.Infrastructure.Database.Entities;

public class FuelEntry
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Canonical stored units: kilometers and liters and currency in smallest unit? We'll store as double/decimal.
    public double DistanceKm { get; set; }
    public double VolumeL { get; set; }
    public decimal TotalCost { get; set; }
}
