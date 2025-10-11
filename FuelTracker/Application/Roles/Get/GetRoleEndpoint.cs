using FuelTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Roles.Get;

public static class GetRoleEndpoint
{
    public static void MapGetRole(this RouteGroupBuilder group)
    {
        group.MapGet("/{id:guid}", Handler);
    }

    private static async Task<IResult> Handler(Guid id, FuelTrackerDbContext db)
    {
        var role = await db.Roles
            .Where(r => r.Id == id)
            .Select(r => new RoleResponse(r.Id, r.Name))
            .FirstOrDefaultAsync();
        return role is null ? Results.NotFound() : Results.Ok(role);
    }
}
