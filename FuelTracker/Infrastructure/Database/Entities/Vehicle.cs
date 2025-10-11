namespace FuelTracker.Infrastructure.Database.Entities;

public class Vehicle
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    // Owner of the vehicle (so each user can have multiple vehicles)
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    // Required vehicle display name/label
    public required string Name { get; set; }

    // Optional details
    public string? Make { get; set; }
    public string? Model { get; set; }
    public int? Year { get; set; }
    public string? FuelType { get; set; }

    public ICollection<FuelEntry> FuelEntries { get; set; } = new List<FuelEntry>();
}
