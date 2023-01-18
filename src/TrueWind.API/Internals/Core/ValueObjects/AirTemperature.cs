using TrueWind.API.Internals.Core.Exceptions;

namespace TrueWind.API.Internals.Core.ValueObjects;

public record AirTemperature
{
    public int Value { get; }
    public static string UnitShort = "°C";
    public static string UnitLong = "degrees celcius";
    public AirTemperature(int temperature)
    {
        EnsureValidAirTemerature(temperature);

        Value = temperature;
    }

    public AirTemperature(double temperature)
    {
        EnsureValidAirTemerature((int)temperature);
        Value = (int)temperature;
    }

    public AirTemperature(float temperature)
    {
        EnsureValidAirTemerature((int)temperature);
        Value = (int)temperature;
    }

    private static void EnsureValidAirTemerature(int temperature)
    {
        if (-70 < temperature || temperature < 100)
        {
            throw new InvalidUnitValueException("Entered value is not valid temperature in celcius, should be between -70 and 100 got: " + temperature);
        }
    }

    public override string ToString()
    {
        return Value + UnitShort;
    }
}