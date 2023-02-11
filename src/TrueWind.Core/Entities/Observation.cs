using TrueWind.Core.ValueObjects;

namespace TrueWind.Core.Entities;

public sealed record Observation
{
    public Observation(string source, GeoPoint geoPoint, DateTime observedTime, WindSpeed? avgWind, WindSpeed? gustSpeed, Direction? windDirection, AirTemperature? airTemperature, AirPressure? airPressure)
    {
        Source = source;
        GeoPoint = geoPoint;
        ObservedTime = observedTime;
        AvgWind = avgWind;
        GustSpeed = gustSpeed;
        WindDirection = windDirection;
        AirTemperature = airTemperature;
        AirPressure = airPressure;
    }

    public string Source { get; }
    public GeoPoint GeoPoint { get; }
    public DateTime ObservedTime { get; }
    public WindSpeed? AvgWind { get; }
    public WindSpeed? GustSpeed { get; }
    public Direction? WindDirection { get; }
    public AirTemperature? AirTemperature { get; }
    public AirPressure? AirPressure { get; }
}