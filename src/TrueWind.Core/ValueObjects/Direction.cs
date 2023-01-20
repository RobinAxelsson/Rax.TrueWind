using TrueWind.Core.Exceptions;

namespace TrueWind.Core.ValueObjects;

public record Direction
{
    public int Value { get; }
    public int Height { get; }
    public static string UnitShort = "°";
    public static string UnitLong = "degrees";
    public Direction(int direction, int height)
    {
        EnsureValid(direction);

        Value = direction;
        Height = height;
    }

    private static void EnsureValid(int direction)
    {
        if (direction < 0 || 360 < direction)
        {
            throw new InvalidUnitValueException("Entered value is not valid direction degrees, should be >= 0 and <360 got: " + direction);
        }
    }

    public override string ToString()
    {
        return Value + UnitShort;
    }
}