using TrueWind.Core.Exceptions;

namespace TrueWind.API.Internals.Core.ValueObjects;

public record AirPressure
{
    public int Value { get; }
    public static string UnitShort = "hPa";
    public static string UnitLong = "hektopascal";
    public AirPressure(int airPressure)
    {
        EnsureValidAirPressure(airPressure);

        Value = airPressure;
    }

    public AirPressure(double airPressure)
    {
        EnsureValidAirPressure((int)airPressure);
        Value = (int)airPressure;
    }

    public AirPressure(float airPressure)
    {
        EnsureValidAirPressure((int)airPressure);
        Value = (int)airPressure;
    }

    private static void EnsureValidAirPressure(int airPressure)
    {
        if (airPressure < 880 || 1100 < airPressure)
        {
            throw new InvalidUnitValueException("Entered value is not valid hPa air pressure, should be between 880 and 1100 got: " + airPressure);
        }
    }

    public override string ToString()
    {
        return Value + UnitShort;
    }
}