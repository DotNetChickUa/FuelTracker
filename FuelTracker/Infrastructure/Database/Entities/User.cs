namespace FuelTracker.Infrastructure.Database.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public required string Email { get; set; }
    public required byte[] PasswordHash { get; set; }
    public required byte[] PasswordSalt { get; set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}