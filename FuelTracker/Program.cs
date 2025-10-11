using System.Security.Claims;
using FuelTracker.Application.Identity;
using FuelTracker.Application.Identity.Auth;
using FuelTracker.Application.Units;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using FuelTracker.Components;
using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
builder.Services.AddScoped<IUnitService, UnitService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.AddDatabase();
builder.AddAuth();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await using var scope = app.Services.CreateAsyncScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<FuelTrackerDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapPost("api/account/login", async (
    HttpContext context,
    FuelTrackerDbContext dbContext,
    [FromForm] string email,
    [FromForm] string password,
    [FromForm] string? returnUrl) =>
{
    var user = await dbContext.Users
        .Include(u => u.UserRoles)
        .ThenInclude(ur => ur.Role)
        .FirstOrDefaultAsync(u => u.Email == email);

    if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt))
    {
        var redirect = "/Login?error=1" +
                       (string.IsNullOrWhiteSpace(returnUrl) ? "" : $"&returnUrl={Uri.EscapeDataString(returnUrl)}");
        return Results.Redirect(redirect);
    }

    var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Name, user.Email)
    };

    foreach (var role in user.UserRoles)
    {
        claims.Add(new Claim(ClaimTypes.Role, role.Role.Name));
    }

    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    var principal = new ClaimsPrincipal(identity);

    var authProperties = new AuthenticationProperties
    {
        IsPersistent = true,
        AllowRefresh = true,
        IssuedUtc = DateTimeOffset.UtcNow,
        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
    };

    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

    var target = NormalizeReturnUrl(returnUrl);
    return Results.Redirect(target);


    static string NormalizeReturnUrl(string? ru)
    {
        if (string.IsNullOrWhiteSpace(ru))
        {
            return "/";
        }

        if (Uri.TryCreate(ru, UriKind.Relative, out _))
        {
            return ru;
        }

        return "/";
    }
});
app.MapPost("api/account/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync();
    return Results.Redirect("/");
});
app.Run();