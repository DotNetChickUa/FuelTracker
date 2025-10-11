using FuelTracker.Application.Roles.Create;
using FuelTracker.Application.Roles.Delete;
using FuelTracker.Application.Roles.Get;
using FuelTracker.Application.Roles.List;
using FuelTracker.Application.Roles.Update;

namespace FuelTracker.Application.Roles;

public static class RolesModule
{
    public static void MapRoles(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/roles")
            .RequireAuthorization(policy => policy.RequireRole(Infrastructure.Roles.Admin));

        group.MapListRoles();
        group.MapGetRole();
        group.MapCreateRole();
        group.MapUpdateRole();
        group.MapDeleteRole();
    }
}
