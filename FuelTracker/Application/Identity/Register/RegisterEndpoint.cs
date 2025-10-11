namespace FuelTracker.Application.Identity.Register;

public static class RegisterEndpoint
{
    public static void MapRegister(this RouteGroupBuilder group)
    {
        group.MapPost("/register", Handler);
        // .RequireAuthorization("Admin");
    }

    private static async Task<IResult> Handler(RegisterRequest request, RegisterHandler handler)
    {
        await handler.Handle(request);
        return Results.Created();
    }
}