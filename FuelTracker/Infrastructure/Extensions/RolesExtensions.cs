using FuelTracker.Application.Roles.Create;
using FuelTracker.Application.Roles.Delete;
using FuelTracker.Application.Roles.Update;

namespace FuelTracker.Infrastructure.Extensions;

public static class RolesExtensions
{
    public static void AddRoles(this IHostApplicationBuilder builder)
    {
        builder.Services.AddScoped<CreateRoleHandler>();
        builder.Services.AddScoped<UpdateRoleHandler>();
        builder.Services.AddScoped<DeleteRoleHandler>();
    }
}
