namespace FuelTracker.Application.Identity.Login;

public record LoginResponse(string AccessToken, long ExpiresAt)
{
    public bool IsExpired => ExpiresAt <= DateTimeOffset.UtcNow.ToUnixTimeSeconds();
};