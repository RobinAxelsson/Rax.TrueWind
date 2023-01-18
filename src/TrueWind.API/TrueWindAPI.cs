using TrueWind.API.Internals.Services.Smhi;
using TrueWind.API.Public;

namespace TrueWind.API;
public class TrueWindAPI
{
    private SmhiGateway? _smhiGateway;
    private SmhiGateway SmhiGateway => _smhiGateway ??= new SmhiGateway();
    public async Task<RestDtoForecast> GetForecast() {
        var forecast = await SmhiGateway.GetGkssData();
        var dto = new RestDtoForecast(forecast.ApprovedTime);
        return dto;
    }
}