﻿namespace TrueWind.API.Internals.Core.ValueObjects;

public sealed record Forecast
{
    public Forecast(string source, DateTime approvedTime, DateTime validTime, WindSpeed avgWind, WindSpeed maxWind, Direction windDirection, AirTemperature airTemperature, AirPressure airPressure)
    {
        Source = source;
        ApprovedTime = approvedTime;
        ValidTime = validTime;
        AvgWind = avgWind;
        MaxWind = maxWind;
        WindDirection = windDirection;
        AirTemperature = airTemperature;
        AirPressure = airPressure;
    }
    public string Source { get; }
    public DateTime ApprovedTime { get; }
    public DateTime ValidTime { get; }
    public WindSpeed AvgWind { get; }
    public WindSpeed MaxWind { get; }
    public Direction WindDirection { get; }
    public AirTemperature AirTemperature { get; }
    public AirPressure AirPressure { get; }
}