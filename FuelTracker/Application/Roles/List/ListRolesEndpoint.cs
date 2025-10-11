using FuelTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FuelTracker.Application.Roles.List;

public static class ListRolesEndpoint
{
    public static void MapListRoles(this RouteGroupBuilder group)
    {
        group.MapGet("/", Handler);
    }

    private static async Task<IResult> Handler(FuelTrackerDbContext db)
    {
        var roles = await db.Roles
            .Select(r => new RoleResponse(r.Id, r.Name))
            .ToListAsync();
        return Results.Ok(roles);
    }
}
