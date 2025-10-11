using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Infrastructure.Database;

public class FuelTrackerDbContext(DbContextOptions<FuelTrackerDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<UserRole> UserRoles => Set<UserRole>();

    // New domain sets
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<FuelEntry> FuelEntries => Set<FuelEntry>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuelTrackerDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}