using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Roles.Create;

public class CreateRoleHandler(FuelTrackerDbContext db)
{
    public async Task<RoleResponseResult> Handle(CreateRoleRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return RoleResponseResult.BadRequest("Name is required.");
        }

        var exists = await db.Roles.AnyAsync(r => r.Name == request.Name);
        if (exists)
        {
            return RoleResponseResult.Conflict("Role with the same name already exists.");
        }

        var role = new Role { Name = request.Name.Trim() };
        db.Roles.Add(role);
        await db.SaveChangesAsync();
        var response = new RoleResponse(role.Id, role.Name);
        return RoleResponseResult.Created($"/api/v1/roles/{role.Id}", response);
    }
}
