namespace FuelTracker.Application.Identity.Login;

public static class LoginEndpoint
{
    public static void MapLogin(this RouteGroupBuilder group)
    {
        group.MapPost("/login", Handler);
    }

    private static async Task<IResult> Handler(LoginRequest request, LoginHandler handler)
    {
        var result = await handler.Handle(request);
        return Results.Ok(result);
    }
}