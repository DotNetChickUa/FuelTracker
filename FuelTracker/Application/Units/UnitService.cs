using System;
using Microsoft.AspNetCore.Components;

namespace FuelTracker.Application.Units;

public interface IUnitService
{
    UnitSettings Settings { get; }
    event Action? OnChange;
    void Update(UnitSettings newSettings);
}

public class UnitService : IUnitService, IDisposable
{
    private readonly NavigationManager _nav;
    public UnitSettings Settings { get; private set; } = new();
    public event Action? OnChange;

    public UnitService(NavigationManager nav)
    {
        _nav = nav;
    }

    public void Update(UnitSettings newSettings)
    {
        Settings = newSettings;
        OnChange?.Invoke();
    }

    public void Dispose()
    {
        OnChange = null;
    }
}
