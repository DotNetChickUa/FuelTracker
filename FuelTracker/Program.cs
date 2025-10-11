using FuelTracker.Application.Identity.Auth;
using FuelTracker.Application.Roles;
using FuelTracker.Application.Users;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using FuelTracker.Components;
using FuelTracker.Infrastructure.Database;
using FuelTracker.Infrastructure.Extensions;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();


builder.AddDatabase();
builder.AddAuth();

builder.AddIdentity();
builder.AddUsers();
builder.AddRoles();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/scalar");
    await using var scope = app.Services.CreateAsyncScope();
    await using var dbContext = scope.ServiceProvider.GetRequiredService<FuelTrackerDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapIdentity();
app.MapUsers();
app.MapRoles();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();