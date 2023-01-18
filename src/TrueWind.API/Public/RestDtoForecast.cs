namespace TrueWind.API.Public;
public sealed record RestDtoForecast
{
    public RestDtoForecast(string approvedTime)
    {
        ApprovedTime = approvedTime;
    }

    public string ApprovedTime { get; }

    //public float WindSpeed { get; }
    //public float WindMax { get; }
    //public int WindDirection { get; }
    //public int AirTemperature { get; }
    //public int AirPressure { get; }
}