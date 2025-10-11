namespace FuelTracker.Infrastructure.Database.Entities;

public class Role
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public required string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}