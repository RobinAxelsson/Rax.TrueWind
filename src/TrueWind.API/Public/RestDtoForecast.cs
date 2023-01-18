namespace TrueWind.API.Public;
public sealed record RestDtoForecast
{
    public RestDtoForecast(float windSpeed, float gustSpeed, int windDirection, int airTemperature, int airPressure)
    {
        WindSpeed_ms = windSpeed;
        GustSpeed_ms = gustSpeed;
        WindDirection_deg = windDirection;
        AirTemperature_celcius = airTemperature;
        AirPressure_hPa = airPressure;
    }

    public float WindSpeed_ms { get; }
    public float GustSpeed_ms { get; }
    public int WindDirection_deg { get; }
    public int AirTemperature_celcius { get; }
    public int AirPressure_hPa { get; }
}