using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Users.AssignRole;

public class AssignUserRoleHandler(FuelTrackerDbContext dbContext)
{
    public async Task<bool> Handle(
        Guid userId,
        string[] roles)
    {
        var user = await dbContext.Users
            .AsTracking()
            .Include(x => x.UserRoles)
            .FirstOrDefaultAsync(u => u.Id == userId);
        if (user is null)
        {
            return false;
        }

        var newRoles = await dbContext.Roles.Where(x => roles.Contains(x.Name)).ToListAsync();
        user.UserRoles.Clear();
        foreach (var role in newRoles)
        {
            user.UserRoles.Add(new UserRole { RoleId = role.Id, UserId = user.Id });
        }
        
        await dbContext.SaveChangesAsync();
        return true;
    }
}