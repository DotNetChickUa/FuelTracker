namespace FuelTracker.Infrastructure.Database.Entities;

public class FuelEntry
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    // Date of fill-up (stored as UTC)
    public DateTime Date { get; set; } = DateTime.UtcNow;

    // Odometer reading at the time of fill-up (km, canonical)
    public double OdometerKm { get; set; }

    // Quantity and total amount
    public double VolumeL { get; set; }
    public decimal TotalCost { get; set; }

    // Optional metadata
    public string? Station { get; set; }
    public string? Brand { get; set; }
    public string? Grade { get; set; }
    public string? Notes { get; set; }
}
