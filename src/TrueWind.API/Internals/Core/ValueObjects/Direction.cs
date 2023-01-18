using TrueWind.API.Internals.Core.Exceptions;

namespace TrueWind.API.Internals.Core.ValueObjects;

public record Direction
{
    public int Value { get; }
    public static string UnitShort = "°";
    public static string UnitLong = "degrees";
    public Direction(int direction)
    {
        EnsureValid(direction);

        Value = direction;
    }

    public Direction(double direction)
    {
        EnsureValid((int)direction);
        Value = (int)direction;
    }

    public Direction(float direction)
    {
        EnsureValid((int)direction);
        Value = (int)direction;
    }

    private static void EnsureValid(int direction)
    {
        if (0 <= direction || direction < 360)
        {
            throw new InvalidUnitValueException("Entered value is not valid direction degrees, should be >= 0 and <360 got: " + direction);
        }
    }

    public override string ToString()
    {
        return Value + UnitShort;
    }
}