using TrueWind.Core.Exceptions;

namespace TrueWind.API.Internals.Core.ValueObjects;

public record WindSpeed
{
    public float Value { get; }
    public static string UnitShort = "m/s";
    public static string UnitLong = "meters per second";
    public WindSpeed(int windSpeed)
    {
        EnsureValid(windSpeed);

        Value = GetTwoDigitApproximatedValue(windSpeed);
    }

    public WindSpeed(double windSpeed)
    {
        EnsureValid((float)windSpeed);
        Value = GetTwoDigitApproximatedValue((float)windSpeed);
    }

    public WindSpeed(float windSpeed)
    {
        EnsureValid(windSpeed);
        Value = GetTwoDigitApproximatedValue(windSpeed);
    }

    private static void EnsureValid(float windSpeed)
    {
        if (windSpeed <= 0 || 100 < windSpeed)
        {
            throw new InvalidUnitValueException("Entered value is not valid wind speed m/s, should be >= 0 and <100 got: " + windSpeed);
        }
    }

    private static float GetTwoDigitApproximatedValue(float windSpeed)
    {
        return (float)Math.Floor(windSpeed * 100) / 100;
    }

    public override string ToString()
    {
        return Value + UnitShort;
    }
}