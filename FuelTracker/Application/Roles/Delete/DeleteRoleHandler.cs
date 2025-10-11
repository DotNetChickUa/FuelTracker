using FuelTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Roles.Delete;

public class DeleteRoleHandler(FuelTrackerDbContext db)
{
    public async Task<RoleResponseResult> Handle(Guid id)
    {
        var role = await db.Roles.FirstOrDefaultAsync(r => r.Id == id);
        if (role is null)
        {
            return RoleResponseResult.NotFound();
        }

        db.Roles.Remove(role);
        await db.SaveChangesAsync();
        return RoleResponseResult.NoContent();
    }
}
