using System;

namespace FuelTracker.Application.Units;

public class UnitSettings
{
    public string CurrencyIsoCode { get; set; } = "USD"; // default, could be from locale
    public DistanceUnit DistanceUnit { get; set; } = DistanceUnit.Kilometer;
    public VolumeUnit VolumeUnit { get; set; } = VolumeUnit.Liter;
    public string TimeZone { get; set; } = TimeZoneInfo.Local.Id;
}
