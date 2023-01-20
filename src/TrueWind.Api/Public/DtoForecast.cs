namespace TrueWind.Api.Public;
public sealed record DtoForecast
{
    public DtoForecast(float windSpeed_ms, float gustSpeed_ms, int windDirection_deg, int airTemperature_celcius, int airPressure_hPa)
    {
        WindSpeed_ms = windSpeed_ms;
        GustSpeed_ms = gustSpeed_ms;
        WindDirection_deg = windDirection_deg;
        AirTemperature_celcius = airTemperature_celcius;
        AirPressure_hPa = airPressure_hPa;
    }

    public float WindSpeed_ms { get; }
    public float GustSpeed_ms { get; }
    public int WindDirection_deg { get; }
    public int AirTemperature_celcius { get; }
    public int AirPressure_hPa { get; }
}
