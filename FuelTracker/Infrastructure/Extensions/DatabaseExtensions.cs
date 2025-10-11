using FuelTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FuelTracker.Infrastructure.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabase(this IHostApplicationBuilder builder)
    {
        builder.Services.AddDbContext<FuelTrackerDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}

public class FuelTrackerDbContextFactory : IDesignTimeDbContextFactory<FuelTrackerDbContext>
{
     public FuelTrackerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FuelTrackerDbContext>()
            .UseSqlite("DataSource=app.db;Cache=Shared");
        return new FuelTrackerDbContext(optionsBuilder.Options);
    }
}