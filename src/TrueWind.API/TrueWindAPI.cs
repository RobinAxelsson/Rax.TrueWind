using TrueWind.API.Internals.Services.Smhi;
using TrueWind.API.Public;

namespace TrueWind.API;
public class TrueWindAPI
{
    private SmhiGateway? _smhiGateway;
    private SmhiGateway SmhiGateway => _smhiGateway ??= new SmhiGateway();
    public async Task<RestDtoForecast> GetForecast() {
        var forecast = await SmhiGateway.GetGkssData();
        var dto = new RestDtoForecast(
            windSpeed: forecast.AvgWind.Value,
            gustSpeed: forecast.GustSpeed.Value,
            windDirection: forecast.WindDirection.Value,
            airTemperature: forecast.AirTemperature.Value,
            airPressure: forecast.AirPressure.Value);
        return dto;
    }
}