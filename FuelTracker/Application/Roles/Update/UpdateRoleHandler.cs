using FuelTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Roles.Update;

public class UpdateRoleHandler(FuelTrackerDbContext db)
{
    public async Task<RoleResponseResult> Handle(Guid id, UpdateRoleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return RoleResponseResult.BadRequest("Name is required.");
        }

        var role = await db.Roles
            .AsTracking()
            .FirstOrDefaultAsync(r => r.Id == id);
        if (role is null)
        {
            return RoleResponseResult.NotFound();
        }

        var conflict = await db.Roles.AnyAsync(r => r.Id != id && r.Name == request.Name);
        if (conflict)
        {
            return RoleResponseResult.Conflict("Another role with the same name already exists.");
        }

        role.Name = request.Name.Trim();
        await db.SaveChangesAsync();
        return RoleResponseResult.NoContent();
    }
}
