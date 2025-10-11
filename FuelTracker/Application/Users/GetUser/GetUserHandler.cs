using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Users.GetUser;

public class GetUserHandler(FuelTrackerDbContext dbContext)
{
    public Task<User?> Handle(Guid request)
    {
        return dbContext.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id == request);
    }
}