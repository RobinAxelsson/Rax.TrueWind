using TrueWind.Api.Public;
using TrueWind.Smhi;

namespace TrueWind.Api;
public class TrueWindApi
{
    private SmhiAPI? _smhiGateway;
    private SmhiAPI SmhiGateway => _smhiGateway ??= new SmhiAPI();
    public async Task<DtoForecast> GetForecast() {
        var forecast = await SmhiGateway.GetGkssData();
        var dto = new DtoForecast(
            windSpeed_ms: forecast.AvgWind.Value,
            gustSpeed_ms: forecast.GustSpeed.Value,
            windDirection_deg: forecast.WindDirection.Value,
            airTemperature_celcius: forecast.AirTemperature.Value,
            airPressure_hPa: forecast.AirPressure.Value);
        return dto;
    }
}