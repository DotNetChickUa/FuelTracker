using FuelTracker.Application.Identity.Login;
using FuelTracker.Application.Identity.Register;

namespace FuelTracker.Application.Identity;

public static class IdentityModule
{
    public static void MapIdentity(this WebApplication app)
    {
        var group = app.MapGroup("/api/v1/identity");
        group.MapLogin();
        group.MapRegister();
    }
}