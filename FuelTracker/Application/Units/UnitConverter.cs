namespace FuelTracker.Application.Units;

public static class UnitConverter
{
    // Documented constants
    public const double GallonUSPerLiter = 1.0 / 3.78541; // gal per L
    public const double LiterPerGallonUS = 3.78541;       // L per gal
    public const double MilePerKm = 1.0 / 1.60934;        // mi per km
    public const double KmPerMile = 1.60934;              // km per mi

    // Convert distance from canonical km to preferred unit
    public static double KmTo(double km, DistanceUnit unit) => unit == DistanceUnit.Kilometer ? km : km * MilePerKm;

    // Convert volume from canonical liters to preferred unit
    public static double LiterTo(double liters, VolumeUnit unit) => unit == VolumeUnit.Liter ? liters : liters * GallonUSPerLiter;

    // Format distance label
    public static string DistanceLabel(DistanceUnit unit) => unit == DistanceUnit.Kilometer ? "km" : "mi";

    // Format volume label
    public static string VolumeLabel(VolumeUnit unit) => unit == VolumeUnit.Liter ? "L" : "gal";

    // Derived stats from canonical km/L values
    // consumption: L per 100 km (canonical)
    public static double ConsumptionLPer100Km(double distanceKm, double volumeL)
        => distanceKm <= 0 ? 0 : (volumeL / distanceKm) * 100.0;

    // distance per volume: km per L (canonical)
    public static double DistancePerLiter(double distanceKm, double volumeL)
        => volumeL <= 0 ? 0 : distanceKm / volumeL;

    // cost per liter (canonical currency)
    public static decimal CostPerLiter(decimal totalCost, double volumeL)
        => volumeL <= 0 ? 0 : totalCost / (decimal)volumeL;

    // cost per km (canonical currency)
    public static decimal CostPerKm(decimal totalCost, double distanceKm)
        => distanceKm <= 0 ? 0 : totalCost / (decimal)distanceKm;

    // View-time conversion helpers for derived metrics
    // Convert consumption to user's preferred (e.g., L/100km or gal/100mi)
    public static double ConvertConsumption(double consumptionLPer100Km, DistanceUnit du, VolumeUnit vu)
    {
        // Start with L/100km -> base value
        var perKm = consumptionLPer100Km / 100.0; // L per km

        // Convert numerator (volume)
        if (vu == VolumeUnit.GallonUS)
        {
            perKm *= GallonUSPerLiter; // convert L to gal
        }
        // Convert denominator (distance)
        if (du == DistanceUnit.Mile)
        {
            perKm *= KmPerMile; // L/ km -> L / mile (or gal / mile)
        }
        return perKm * 100.0; // back to per 100 selected distance unit
    }

    // Convert distance-per-volume metric (km/L -> mi/gal if selected)
    public static double ConvertDistancePerVolume(double kmPerL, DistanceUnit du, VolumeUnit vu)
    {
        var value = kmPerL;
        if (du == DistanceUnit.Mile)
            value *= MilePerKm; // km -> mi
        if (vu == VolumeUnit.GallonUS)
            value *= LiterPerGallonUS; // per L -> per gal increases by 3.78541
        return value; // now in chosen units
    }

    // Convert cost per distance (per km -> per mi if selected)
    public static decimal ConvertCostPerDistance(decimal costPerKm, DistanceUnit du)
        => du == DistanceUnit.Kilometer ? costPerKm : costPerKm * (decimal)KmPerMile;

    // Convert cost per volume (per L -> per gal if selected)
    public static decimal ConvertCostPerVolume(decimal costPerL, VolumeUnit vu)
        => vu == VolumeUnit.Liter ? costPerL : costPerL * (decimal)LiterPerGallonUS;

    public static string ConsumptionLabel(DistanceUnit du, VolumeUnit vu)
        => $"{(vu == VolumeUnit.Liter ? "L" : "gal")}/100{(du == DistanceUnit.Kilometer ? "km" : "mi")}";

    public static string DistancePerVolumeLabel(DistanceUnit du, VolumeUnit vu)
        => $"{(du == DistanceUnit.Kilometer ? "km" : "mi")}/{(vu == VolumeUnit.Liter ? "L" : "gal")}";

    public static string CostPerDistanceLabel(string currency, DistanceUnit du)
        => $"{currency}/{(du == DistanceUnit.Kilometer ? "km" : "mi")}";

    public static string CostPerVolumeLabel(string currency, VolumeUnit vu)
        => $"{currency}/{(vu == VolumeUnit.Liter ? "L" : "gal")}";
}
